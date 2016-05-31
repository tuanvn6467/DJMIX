/*
 * Copyright (c) 2013 Gracenote.
 *
 * This software may not be used in any way or distributed without
 * permission. All rights reserved.
 *
 * Some code herein may be covered by US and international patents.
 */

/*
 *  Name: MusicIDMatch
 *  Description:
 *  This example finds matches based on input text.
 *
 *  Command-line Syntax:
 *  sample clientId clientTag license libraryPath
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using GracenoteSDK;
namespace MusicIdentification
{
    class MusicIDMatch
    {
        /// <summary>
        /// set source id - the id that you want GnMusicIdMatch to return 
        /// </summary>
        public static string sourceId = "xxxxxxxxxxxx";

        private static string dancing_queen_nano_fp = @"../../../../sample_data/dancing_queen_nano_fp.xml";
        private static string dancing_queen_micro_fp = @"../../../../sample_data/dancing_queen_micro_fp.xml";

        static int SUCCESS = 0;
        static int ERROR = 1;

        /// <summary>
        /// GnStatusEventsDelegate : overrider methods of this class to get delegate callbacks
        /// </summary>
        public class LookupStatusEvents : GnStatusEventsDelegate
        {
            /*-----------------------------------------------------------------------------
			 *  StatusEvent
			 */
            public override void
            StatusEvent(GnStatus status, uint percentComplete, uint bytesTotalSent, uint bytesTotalReceived, IGnCancellable canceller)
            {
                Console.Write("\nPerforming MusicID Match Query ...\t");

                switch (status)
                {
                    case GnStatus.kStatusUnknown:
                        Console.Write("Status unknown ");
                        break;

                    case GnStatus.kStatusBegin:
                        Console.Write("Status query begin ");
                        break;

                    case GnStatus.kStatusConnecting:
                        Console.Write("Status  connecting ");
                        break;

                    case GnStatus.kStatusSending:
                        Console.Write("Status sending ");
                        break;

                    case GnStatus.kStatusReceiving:
                        Console.Write("Status receiving ");
                        break;

                    case GnStatus.kStatusComplete:
                        Console.Write("Status complete ");
                        break;

                    default:
                        break;
                }

                Console.WriteLine("\n\t% Complete (" + percentComplete + "),\tTotal Bytes Sent (" + bytesTotalSent + "),\tTotal Bytes Received (" + bytesTotalReceived + ")");
            }

        }


        /// <summary>
        /// GetUser:
        /// Return a stored user if exists, or create new user and store it for use next time.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="clientId"></param>
        /// <param name="clientIdTag"></param>
        /// <param name="applicationVersion"></param>
        /// <param name="lookupMode"></param>
        /// <returns></returns>
        private static GnUser
        GetUser(GnManager manager, string clientId, string clientIdTag, string applicationVersion, GnLookupMode lookupMode)
        {
            string serializedUser = String.Empty;

            GnUserRegisterMode userRegMode = GnUserRegisterMode.kUserRegisterModeOnline;
            if (lookupMode == GnLookupMode.kLookupModeLocal)
                userRegMode = GnUserRegisterMode.kUserRegisterModeLocalOnly;

            // read stored user data from file 
            if (File.Exists("user.txt"))
            {
                using (StreamReader sr = new StreamReader("user.txt"))
                {
                    serializedUser = sr.ReadToEnd();
                }
            }

            if (serializedUser.Length > 0)
            {
                // pass in clientID (optional) to ensure this serialized user is for this clientID 
                GnUser user = new GnUser(serializedUser, clientId);

                if ((userRegMode == GnUserRegisterMode.kUserRegisterModeLocalOnly) || !user.IsLocalOnly())
                    return user;
                // else desired regmode is online, but user is localonly - discard and register new online user
            }

            // Register new user
            serializedUser = manager.UserRegister(userRegMode, clientId, clientIdTag, applicationVersion).c_str();

            // store user data to file 
            using (StreamWriter outfile = new StreamWriter("user.txt"))
            {
                outfile.Write(serializedUser);
                outfile.Close();
            }

            return new GnUser(serializedUser);
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="match_ord"></param>
        /// <param name="iterableExIDs"></param>
        private static void
        GetMatchInfoXids(int match_ord, GnExternalIdEnumerable iterableExIDs)
        {
            int xid_ord = 1;
            foreach (GnExternalId xid in iterableExIDs)
            {
                Console.WriteLine("\t\t xid " + xid_ord + " value: " + xid.Value + " source: " + xid.Source);
                xid_ord++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match_ord"></param>
        /// <param name="match"></param>
        private static void
        GetMatchInfoTui(int match_ord, GnMatch match)
        {
            Console.WriteLine("\tmatch " + match_ord + " tui value: " + match.Tui + " tag: " + match.TuiTag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="gnResponseMatches"></param>
        /// <returns></returns>
        private static GnMatchEnumerable
        EnumerateMatchInfos(String ident, GnResponseMatches gnResponseMatches)
        {
            GnMatchEnumerable iterable = gnResponseMatches.Matches;
            /* print the total match count*/
            Console.WriteLine("Response for ident " + ident + " : match count = " + iterable.count());
            int match_ord = 1;
            /* Loop over the GnMatch's to extract relevant information*/
            foreach (GnMatch match in iterable)
            {
                Console.WriteLine("\tmatch " + match_ord + " match_type = " + match.MatchInfo);
                Console.WriteLine("\tmatch " + match_ord + " xid count = " + match.ExternalIds.count());
                if (match.ExternalIds.count() > 0)
                {
                    /* Get the XID's (eXternal ID's)  in the GnMatch */
                    GetMatchInfoXids(match_ord, match.ExternalIds);
                }
                else
                {
                    /* Get the Gracenote TUI from the GnMatch*/
                    GetMatchInfoTui(match_ord, match);
                }
                match_ord++;
            }
            Console.WriteLine("End Response for ident " + ident + " \n");
            return iterable;
        }


        /// <summary>
        /// oMusicIDMatchLookupCompare
        /// </summary>
        /// <param name="user"></param>
        private static void
        DoMusicIDMatchLookupCompare(GnUser user)
        {
            string cmx_dancing_queen_fp = "3877 3310 2163 1433 1476 2441 1539 1559 2586 3642 1357 1699 2003 1982 1694 3240 1415 1229 1101 1705 4142 1862 1530 3078 3036 976 2523 2441 2542 1941";
            string compareFP = File.ReadAllText(dancing_queen_nano_fp);
            String unique_ident = "ID_L1";
            Console.WriteLine(" Executing multiple MusicID Match queries with a Lookup and subsequent Compare");

            /* create instance of GnMusicIdMatch */
            LookupStatusEvents midmevents = new LookupStatusEvents();

            /* Set the External ID Source . This should be provided to you by Gracenote with your License Agreement */
            GnMusicIdMatch musicidMatch = new GnMusicIdMatch(user, sourceId, null /*midmevents*/);

            try
            {
                musicidMatch.LookupFingerprint(unique_ident, cmx_dancing_queen_fp);
                Console.WriteLine("Setting Dancing Queen cmx fingerprint for ident " + unique_ident);
            }
            catch (Exception)
            {
                Console.WriteLine("Error setting Dancing Queen cmx fingerprint for ident " + unique_ident);
                throw;
            }

            /* Execute the MusicID Match query */
            musicidMatch.FindMatches();

            /* Get the Response GDO from the MusicID Match query */
            GnResponseMatches gnResponseMatches = musicidMatch.Response(unique_ident);

            /* Enumerate the Match Info GDO's from the Response GDO */
            EnumerateMatchInfos(unique_ident, gnResponseMatches);

            List<string> xids = new List<string>();
            GnMatchEnumerable iterable = gnResponseMatches.Matches;
            foreach (GnMatch match in iterable)
            {
                if (match.ExternalIds.count() > 0)
                {
                    GnExternalIdEnumerable iterableExIDs = match.ExternalIds;
                    foreach (GnExternalId xid in iterableExIDs)
                        xids.Add(xid.Value);
                }
            }

            /* add a valid ID to force a NoMatch match type */
            /* this is only to trigger this match type for demonstration purposes */
            /* xids.Add("211294407"); */

            /* add an ID that we know does not exist to force a NonExist match type */
            /* this is only to trigger this match type for demonstration purposes */
            /* xids.Add("123"); */

            if (xids.Count > 0)      /* check if we have compare data */
            {
                /* do compare query and set the External ID Source .
				 * This should be provided to you by Gracenote with your License Agreement.*/
                GnMusicIdMatch midMatchCompare = new GnMusicIdMatch(user, sourceId, null /*midmevents*/);

                midMatchCompare.CompareFingerprint(unique_ident, compareFP);

                foreach (string id in xids)
                {
                    midMatchCompare.AddCompareData(unique_ident, id);
                }
                midMatchCompare.FindMatches();

                GnResponseMatches compareResult = midMatchCompare.Response(unique_ident);
                EnumerateMatchInfos(unique_ident, gnResponseMatches);
            }
        }


        /// <summary>
        /// DoMusicIDMatchLookup
        /// </summary>
        /// <param name="user"></param>
        /// <param name="fp"></param>
        /// <returns></returns>
        private static List<GnMatchEnumerable> DoMusicIDMatchLookup(GnUser user, string[] fp)
        {
            Console.WriteLine("\n Executing a single MusicID Match query with multiple Lookups");

            /* create instance of GnMusicIdMatch */
            LookupStatusEvents midmevents = new LookupStatusEvents();

            /* Set the External ID Source . This should be provided to you by Gracenote with your License Agreement */
            GnMusicIdMatch musicidMatch = new GnMusicIdMatch(user, sourceId, null /*midmevents*/);

            /* Build the MusicID Match  query . The following sample code generates a unique ident to use for each Lookup. */
            for (int i = 0; i < fp.Length; i++)
            {
                string ident = "ID_" + i;
                musicidMatch.LookupFingerprint(ident, fp[i]);
                Console.WriteLine("Setting cmx fingerprint for ident " + ident);
            }

            /* Find matches */
            musicidMatch.FindMatches();

            List<GnMatchEnumerable> responseList = new List<GnMatchEnumerable>();

            /* Get results from the MusicID Match query */
            for (int i = 0; i < fp.Length; i++)
            {
                /* unique identifier set above in musicidMatch.SetLookupFp() */
                String ident = "ID_" + i;
                GnResponseMatches gnResponseMatches = musicidMatch.Response(ident);
                responseList.Add(EnumerateMatchInfos(ident, gnResponseMatches));
            }

            return responseList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        private static void
        DoMusicIDMatch(GnUser user)
        {
            string[] fp = {
                "1537 5078 3448 3020 1380 2261 2155 2429 2183 1606 1204 1385 1401 1869 1804 2060 7502 4120 4754 1164 1119 1855 2546 1599 1765 638 473 855 987 1325",
                "5914 5676 4090 2804 2387 1924 1873 1567 1305 1369 1012 848 782 627 582 5810 3007 5801 2098 2241 677 1575 2144 1685 1839 1443 1290 1288 975 885",
                "1325 3330 4010 2649 2367 2210 2949 2249 2828 1656 2167 1751 1270 1049 949 1646 3089 4330 3674 2103 2938 3600 1693 4204 1124 1230 1426 638 621 444",
                "3888 10144 4457 2822 3947 2192 2014 1539 539 366 258 172 193 89 140 3668 6456 4916 10571 2475 846 1083 904 669 390 369 222 103 58 32",
                "525 661 21488 301 2550 506 1189 216 421 285 258 382 435 1663 1878 1687 1414 2475 768 7938 3715 4832 1119 868 664 273 612 576 2539 3280",
                "941 5866 5606 2894 2495 2135 1666 1490 1268 1117 2122 1422 1068 1231 1441 814 5989 6396 2073 3479 2216 1137 1808 1270 968 2613 1372 725 717 1183",
                "1959 631 1318 2482 3610 3462 3939 1982 1691 2073 2018 2113 1952 1484 2046 2840 764 1762 3819 4521 4255 4751 2329 1993 1465 694 1133 970 272 1191",
                "3652 1023 591 517 581 1400 1890 2604 3127 3378 4422 3709 1935 1866 2067 7327 1140 146 151 643 3788 4159 5796 3362 1136 2229 1678 172 618 416",
                "3877 3310 2163 1433 1476 2441 1539 1559 2586 3642 1357 1699 2003 1982 1694 3240 1415 1229 1101 1705 4142 1862 1530 3078 3036 976 2523 2441 2542 1941"
            };

            /* Lookup matches by cmx fingerprint */
            List<GnMatchEnumerable> responseList = DoMusicIDMatchLookup(user, fp);

            /* Resolve matches by nano fingerprint */
            DoMusicIDMatchLookupCompare(user);
        }


        /// <summary>
        /// Sample app start (main)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Mai1n(string[] args)
        {
            string licenseFile;
            string gnsdkLibraryPath;
            string clientId;
            string clientIdTag;
            string applicationVersion = "1.0.0.0";  // Increment with each version of your app 
            GnLookupMode lookupMode;
            int result = ERROR;

            Console.OutputEncoding = Encoding.UTF8;
            if (args.Length == 5)
            {
                clientId = args[0];
                clientIdTag = args[1];
                licenseFile = args[2];
                gnsdkLibraryPath = args[3];

                if (args[4] == "online")
                {
                    lookupMode = GnLookupMode.kLookupModeOnline;
                }
                else if (args[4] == "local")
                {
                    lookupMode = GnLookupMode.kLookupModeLocal;
                }
                else
                {
                    Console.Write("Incorrect lookupMode specified.\n");
                    Console.Write("Please choose either \"local\" or \"online\"\n");
                    return ERROR;
                }
            }
            else
            {
                Console.Write("\nUsage:  clientId clientIdTag license gnsdkLibraryPath lookupMode\n");
                return ERROR;
            }

            // GNSDK initialization 
            try
            {
                // Initialize SDK
                GnManager manager = new GnManager(gnsdkLibraryPath, licenseFile, GnLicenseInputMode.kLicenseInputModeFilename);

                // Display SDK version
                Console.WriteLine("\nGNSDK Product Version : " + manager.ProductVersion + " \t(built " + manager.BuildDate + ")");

                // Enable GNSDK logging 
                GnLog sampleLog = new GnLog("sample.log", null);
                GnLogFilters filters = new GnLogFilters();
                sampleLog.Filters(filters.Error().Warning());               // Include only error and warning entries 
                GnLogColumns columns = new GnLogColumns();
                sampleLog.Columns(columns.All());			                // Add all columns to log: timestamps, thread IDs, etc 
                GnLogOptions options = new GnLogOptions();
                sampleLog.Options(options.MaxSize(0).Archive(false));       // Max size of log: 0 means a new log file will be created each run. Archive option will save old log else it will regenerate the log each time 
                sampleLog.Enable(GnLogPackageType.kLogPackageAllGNSDK);     // Include entries for all packages and subsystems 

                // Get GnUser instance to allow us to perform queries 
                GnUser user = GetUser(manager, clientId, clientIdTag, applicationVersion, lookupMode);

                // Perform sample MusicIDMatch query 
                DoMusicIDMatch(user);

                // Success
                result = SUCCESS;
            }

            /* All gracenote sdk objects throws GnException */
            catch (GnException e)
            {
                Console.WriteLine("Error Code           :: " + e.ErrorCode);
                Console.WriteLine("Error Description    :: " + e.ErrorDescription);
                Console.WriteLine("Error API            :: " + e.ErrorAPI);
                Console.WriteLine("Source Error Code    :: " + e.SourceErrorCode);
                Console.WriteLine("SourceE rror Module :: " + e.SourceErrorModule);
            }
            return result;
        }
    }
}

