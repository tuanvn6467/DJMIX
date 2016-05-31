using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GracenoteSDK;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Microsoft.Win32;
using NAudio.Wave;
using System.Globalization;

namespace MusicIdentification
{
    public partial class f_Main : Form
    {
        private static RichTextBox richTextBox12;
        List<string> listTrackMatched = new List<string>();
        List<string> listTrackMatchedArtist = new List<string>();

        List<string> listTrackMatchedCompare = new List<string>
        {
           "Combat",
           "Kismet",
           "Zenith",
           "Radical",
           "Ravefield",
           "Carbon",
           "Rise Up",
           "Typhoon",
           "The Dancefloor Is Yours",
           "Tear It Off",
           "Bleepdifreak",
        };
        List<string> listTrackMatchedAristCompare = new List<string>
        {


        };


        public f_Main()
        {
            InitializeComponent();

            richTextBox12 = richTextBox1;
        }
        private void f_Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            openFileDialog1.AutoUpgradeEnabled = false; //using FileDialog.AutoUpgradeEnabled = false it will display the old XP sytle dialog box, which then displays correctly
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = openFileDialog1.FileName;
                txt_name.Text = "" + openFileDialog1.SafeFileName + "";
            }
        }
        private async void buttonIdentify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_path.Text))
            {
                MessageBox.Show("Please choose file audio!", "Error");
                return;
            }

            richTextBox1.Text = "";
            string licenseFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + ConfigurationManager.AppSettings["LicenseFile"];
            string gnsdkLibraryPath = ConfigurationManager.AppSettings["GnsdkLibraryPath"];
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string clientIdTag = ConfigurationManager.AppSettings["ClientTag"];
            string licenseFileStr = ConfigurationManager.AppSettings["LicenseFileStr"];
            string applicationVersion = "1.0.0.0";  /* Increment with each version of your app */
            GnLookupMode lookupMode = GnLookupMode.kLookupModeOnline;//GnLookupMode.kLookupModeLocal;
            int result = ERROR;

            /* GNSDK initialization */
            try
            {
                // GnManager manager = new GnManager(gnsdkLibraryPath, licenseFile, GnLicenseInputMode.kLicenseInputModeFilename);
                GnManager manager = new GnManager(gnsdkLibraryPath, licenseFileStr, GnLicenseInputMode.kLicenseInputModeString);

                /* Display SDK version */
                richTextBox1.Text = richTextBox1.Text + ("\nGNSDK Product Version : " + manager.ProductVersion + " \t(built " + manager.BuildDate + ")");

                // Enable GNSDK logging 
                GnLog sampleLog = new GnLog("sample.log", null);
                GnLogFilters filters = new GnLogFilters();
                sampleLog.Filters(filters.Error().Warning());               // Include only error and warning entries 
                GnLogColumns columns = new GnLogColumns();
                sampleLog.Columns(columns.All());                           // Add all columns to log: timestamps, thread IDs, etc 
                GnLogOptions options = new GnLogOptions();
                sampleLog.Options(options.MaxSize(0).Archive(false));       // Max size of log: 0 means a new log file will be created each run. Archive option will save old log else it will regenerate the log each time 
                sampleLog.Enable(GnLogPackageType.kLogPackageAllGNSDK);     // Include entries for all packages and subsystems 

                // Enable Database Support
                EnableStorage();

                GnUser user = GetUser(manager, clientId, clientIdTag, applicationVersion, lookupMode);

                //MusicIdStream.LoadLocale(user);
                int isValid = 0;
                try
                {
                    using (var reader = new MediaFoundationReader(txt_path.Text))
                    {
                        var InputFileFormat = reader.WaveFormat.ToString();
                        isValid = 1;
                        richTextBox1.Text = richTextBox1.Text + ("\n-------Start File Information:-------");
                        richTextBox1.Text = richTextBox1.Text + ("\n" + InputFileFormat);
                        richTextBox1.Text = richTextBox1.Text + ("\n-------End File Information:-------");
                        reader.Dispose();
                        reader.Close();
                        reader.Flush();
                    }

                    MusicidFingerprintAlbum(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Not a supported input file ({0})", ex.Message));
                }
                /*------------------------------------------------------------------*/

                result = SUCCESS;
            }
            catch (GnException ex)
            {
                //MessageBox.Show("GnException : (" + ex.Message.ToString() + ")" + ex.Message, "Error");
                richTextBox1.Text = richTextBox1.Text + ("\nGnException : (" + ex.Message.ToString() + ")" + ex.Message);
            }
        }

        #region Audio
        int SUCCESS = 0;
        int ERROR = 1;
        private string folderPath = Directory.GetCurrentDirectory() + "\\testFile\\";
        private string dbPath = @"../../../../sample_data/sample_db";
        /// <summary>
        /// Callback delegate 
        /// </summary>
        public class LookupStatusEvents : GnStatusEventsDelegate
        {
            /*-----------------------------------------------------------------------------
             *  StatusEvent
             */
            public override void
            StatusEvent(GnStatus status, uint percentComplete, uint bytesTotalSent, uint bytesTotalReceived, IGnCancellable canceller)
            {
                Console.Write("status (");

                switch (status)
                {
                    case GnStatus.kStatusUnknown:
                        Console.Write("Unknown");
                        break;

                    case GnStatus.kStatusBegin:
                        Console.Write("Begin");
                        break;

                    case GnStatus.kStatusConnecting:
                        Console.Write("Connecting");
                        break;

                    case GnStatus.kStatusSending:
                        Console.Write("Sending");
                        break;

                    case GnStatus.kStatusReceiving:
                        Console.Write("Receiving");
                        break;

                    case GnStatus.kStatusDisconnected:
                        Console.Write("Disconnected");
                        break;

                    case GnStatus.kStatusComplete:
                        Console.Write("Complete");
                        break;

                    default:
                        break;
                }

                Console.Write("), complete ({0:D}%), sent ({1:D}), received ({2:D})\n", percentComplete, bytesTotalSent, bytesTotalReceived);
            }

        };

        public class MusicIDFileEvents : GnMusicIdFileEventsDelegate
        {
            /// <summary>
            /// This Method is called when a status event is triggered. 
            /// </summary>
            /// <param name="status"></param>
            /// <param name="percentComplete"></param>
            /// <param name="bytesTotalSent"></param>
            /// <param name="bytesTotalReceived"></param>
            /// <param name="canceller"></param>
            public override void
            StatusEvent(GnStatus status, uint percentComplete, uint bytesTotalSent, uint bytesTotalReceived, IGnCancellable canceller)
            {
                Console.Write("status (");

                switch (status)
                {
                    case GnStatus.kStatusUnknown:
                        Console.Write("Unknown");
                        break;

                    case GnStatus.kStatusBegin:
                        Console.Write("Begin");
                        break;

                    case GnStatus.kStatusConnecting:
                        Console.Write("Connecting");
                        break;

                    case GnStatus.kStatusSending:
                        Console.Write("Sending");
                        break;

                    case GnStatus.kStatusReceiving:
                        Console.Write("Receiving");
                        break;

                    case GnStatus.kStatusDisconnected:
                        Console.Write("Disconnected");
                        break;

                    case GnStatus.kStatusComplete:
                        Console.Write("Complete");
                        break;

                    default:
                        break;
                }

                Console.Write("), complete ({0:D}%), sent ({1:D}), received ({2:D})\n", percentComplete, bytesTotalSent, bytesTotalReceived);
            }

            /// <summary>
            /// This method is called when a MusicIdFile Status Event is triggered.
            /// </summary>
            /// <param name="fileinfo"></param>
            /// <param name="status"></param>
            /// <param name="currentFile"></param>
            /// <param name="totalFiles"></param>
            /// <param name="canceller"></param>
            public override void MusicIdFileStatusEvent(GnMusicIdFileInfo fileinfo, GnMusicIdFileCallbackStatus status, uint currentFile, uint totalFiles, IGnCancellable canceller)
            {
                GnMusicIdFileInfoStatus midfStatus;

                switch (status)
                {
                    case GnMusicIdFileCallbackStatus.kMusicIdFileCallbackStatusProcessingComplete:
                        /* Debug.WriteLine(" : Status - Processing completed", fileinfo.Identifier); */
                        midfStatus = fileinfo.Status();
                        if ((int)midfStatus == 4 || (int)midfStatus == 5)
                        {
                            Console.Write("\n*File " + currentFile + " of " + totalFiles + "*\n");
                            DisplayAlbums(fileinfo.AlbumResponse, midfStatus);
                        }
                        break;

                    default:
                        break;
                }
            }

            /// <summary>
            /// This will be called when a fingerprint needs to gathered from file.
            /// </summary>
            /// <param name="fileInfo"></param>
            /// <param name="currentFile"></param>
            /// <param name="totalFiles"></param>
            /// <param name="canceller"></param>
            public override void GatherFingerprint(GnMusicIdFileInfo fileInfo, uint currentFile, uint totalFiles, IGnCancellable canceller)
            {
                Console.Write("\n GatherFingerprint  *File " + currentFile + " of " + totalFiles + "*\n");
            }

            /// <summary>
            /// This method will be called when metadata is needed  for a file. 
            /// A typical use for this callback is to read file tags (ID3, etc) for the basic 
            /// metadata of the track.  To keep the sample code simple, we went with .wav files
            /// To keep the sample code simple, we went with .wav files
            /// and hardcoded in metadata for just one of the sample tracks.  (MYAPP_SAMPLE_FILE_5)
            /// </summary>
            /// <param name="fileInfo"></param>
            /// <param name="currentFile"></param>
            /// <param name="totalFiles"></param>
            /// <param name="canceller"></param>
            public override void GatherMetadata(GnMusicIdFileInfo fileInfo, uint currentFile, uint totalFiles, IGnCancellable canceller)
            {
                Console.Write("\n GatherMetadata  *File " + currentFile + " of " + totalFiles + "*\n");
            }

            /// <summary>
            /// This method will be called when there is an album available 
            /// </summary>
            /// <param name="albumResult"></param>
            /// <param name="currentAlbum"></param>
            /// <param name="totalAlbums"></param>
            /// <param name="canceller"></param>
            public override void MusicIdFileAlbumResult(GnResponseAlbums albumResult, uint currentAlbum, uint totalAlbums, IGnCancellable canceller)
            {
                Console.Write("\n MusicIdFileAlbumResult  *Album " + currentAlbum + " of " + totalAlbums + "*\n");
            }

            /// <summary>
            /// This method will be called when a FindMatches call is made and a result is available. 
            /// </summary>
            /// <param name="matchesResult"></param>
            /// <param name="currentAlbum"></param>
            /// <param name="totalAlbums"></param>
            /// <param name="canceller"></param>
            public override void MusicIdFileMatchResult(GnResponseDataMatches matchesResult, uint currentAlbum, uint totalAlbums, IGnCancellable canceller)
            {
                Console.Write("\n MusicIdFileMatchResult  *Match Result " + currentAlbum + " of " + totalAlbums + "*\n");
            }

            /// <summary>
            /// This method will be called when there is no result available for a given MusicIdFileInfo 
            /// </summary>
            /// <param name="fileInfo"></param>
            /// <param name="currentFile"></param>
            /// <param name="totalFiles"></param>
            /// <param name="canceller"></param>
            public override void MusicIdFileResultNotFound(GnMusicIdFileInfo fileInfo, uint currentFile, uint totalFiles, IGnCancellable canceller)
            {
                Console.Write("\n MusicIdFileResultNotFound  *File " + currentFile + " of " + totalFiles + "*\n");
            }

            /// <summary>
            /// This will be called when the MusicIdFile find operation is completed.
            /// </summary>
            /// <param name="completeError">Any error that occurred will be returned. </param>
            public override void MusicIdFileComplete(GnError completeError)
            {
                Console.Write("\n MusicIdFileComplete " + completeError.ErrorDescription());
            }

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public class LookupStatusEvents : GnStatusEventsDelegate
        //{

        //    /// <summary>
        //    /// Overrride implemented for status events . 
        //    /// </summary>
        //    /// <param name="status"></param>
        //    /// <param name="percentComplete"></param>
        //    /// <param name="bytesTotalSent"></param>
        //    /// <param name="bytesTotalReceived"></param>
        //    /// <param name="canceller"></param>
        //    public override void
        //    StatusEvent(GnStatus status, uint percentComplete, uint bytesTotalSent, uint bytesTotalReceived, IGnCancellable canceller)
        //    {
        //        Console.Write("status (");

        //        switch (status)
        //        {
        //            case GnStatus.kStatusUnknown:
        //                Console.Write("Unknown");
        //                break;

        //            case GnStatus.kStatusBegin:
        //                Console.Write("Begin");
        //                break;

        //            case GnStatus.kStatusConnecting:
        //                Console.Write("Connecting");
        //                break;

        //            case GnStatus.kStatusSending:
        //                Console.Write("Sending");
        //                break;

        //            case GnStatus.kStatusReceiving:
        //                Console.Write("Receiving");
        //                break;

        //            case GnStatus.kStatusDisconnected:
        //                Console.Write("Disconnected");
        //                break;

        //            case GnStatus.kStatusComplete:
        //                Console.Write("Complete");
        //                break;

        //            default:
        //                break;
        //        }

        //        Console.Write("), complete ({0:D}%), sent ({1:D}), received ({2:D})\n", percentComplete, bytesTotalSent, bytesTotalReceived);
        //    }

        //};



        /// <summary>
        /// EnableStorage:
        /// Enabling a storage module for GNSDK enables the SDK to use it 
        /// for caching of online queries, storing Playlist Collections, and
        /// to access to Local Databases for offline queries.
        /// Using a storage module is optional and the SDK is capable of operating
        /// without those features if you so chose.
        /// </summary>
        private void EnableStorage()
        {
            // Instantiate SQLite module to use as our database 
            GnStorageSqlite storageSqlite = GnStorageSqlite.Enable();

            // Set folder location for sqlite storage 
            storageSqlite.StorageLocation = ".";
        }

        /// <summary>
        /// EnableLocalLookups:
        /// Enabling a Local Lookup module gives the SDK the ability to perform
        /// certain queries without going online. This can enable an completely
        /// off-line mode for your application, or can act as a performance boost
        /// over going online for some queries.
        /// </summary>
        private void EnableLocalLookups()
        {


            // Instantiate Local Lookup module to enable local queries
            GnLookupLocal gnLookupLocal = GnLookupLocal.Enable();
            gnLookupLocal.StorageLocation(GnLocalStorageName.kLocalStorageAll, dbPath);
            // Display Local Database version 
            uint ordinal = gnLookupLocal.StorageInfoCount(GnLocalStorageName.kLocalStorageMetadata, GnLocalStorageInfo.kLocalStorageInfoVersion);
            string gdb_version = gnLookupLocal.StorageInfo(GnLocalStorageName.kLocalStorageMetadata, GnLocalStorageInfo.kLocalStorageInfoVersion, ordinal);
            Console.Write("Gracenote Local Database Version : %s\n", gdb_version);
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
        private GnUser GetUser(GnManager manager, string clientId, string clientIdTag, string applicationVersion, GnLookupMode lookupMode)
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
        ///  LoadLocale:
        /// 
        /// </summary>
        /// <param name="user"></param>
        void LoadLocale(GnUser user)
        {
            using (LookupStatusEvents localeEvents = new LookupStatusEvents())
            {
                GnLocale locale = new GnLocale(
                    GnLocaleGroup.kLocaleGroupMusic,     // Locale group
                    GnLanguage.kLanguageEnglish,         // Language 
                    GnRegion.kRegionDefault,             // Region 
                    GnDescriptor.kDescriptorSimplified,  // Descriptor 
                    user,                                // User 
                    null                                 // locale Events object 
                    );

                locale.SetGroupDefault();
            }
        }

        /*-----------------------------------------------------------------------------
		 *  DisplayGnTitle
		 */
        private void DisplayGnTitle(GnAlbum album)
        {
            GnTitle gnTitle = album.Title;
            richTextBox1.Text = richTextBox1.Text + ("\n          Title: " + gnTitle.Display);
        }

        /*-----------------------------------------------------------------------------
		 *  DisplayFindAlbumResutlsByFingerprint
		 */
        private void
        DisplayFindAlbumResutlsByFingerprint(GnResponseAlbums response)
        {
            var responses = response;
            GnAlbumEnumerable albumEnumerable = response.Albums;
            if (albumEnumerable.count() > 0)
            {
                GnAlbum finalgnAlbum = null;
                var countAlbum = 1;
                /* richTextBox1.Text = richTextBox1.Text +("    Album count: " + albumEnumerable.count()); */
                foreach (GnAlbum album in albumEnumerable)
                {
                    /* DisplayGnTitle(album); */
                    if (album != null)
                    {
                        richTextBox1.Text = richTextBox1.Text + ("\n   -------------------------  Album [" + countAlbum + "]: ----------------------------");
                        richTextBox1.Text = richTextBox1.Text + ("\n          Title: " + album.Title.Display);
                        richTextBox1.Text = richTextBox1.Text + ("\n          Artist: " + album.Artist.Name.Display);

                        var track = album.TrackMatched();
                        listTrackMatched.Add(track.Title.Display);
                        listTrackMatchedArtist.Add(track.Artist.Name.Display);
                        richTextBox1.Text = richTextBox1.Text + ("\n         Track Title: " + track.Title.Display);
                        richTextBox1.Text = richTextBox1.Text + ("\n         Track Artist: " + track.Artist.Name.Display);
                        richTextBox1.Text = richTextBox1.Text + ("\n         Track number: " + track.TrackNumber);
                        richTextBox1.Text = richTextBox1.Text + ("\n   -------------------------  Album [" + countAlbum + "]: ----------------------------\n");
                        countAlbum++;
                    }
                }
                //if (finalgnAlbum != null)
                //{
                //    GnTitle iGnTitle = finalgnAlbum.Title;
                //    richTextBox1.Text = richTextBox1.Text + ("\n    Last album:");
                //    richTextBox1.Text = richTextBox1.Text + ("\n          Title: " + iGnTitle.Display);
                //    richTextBox1.Text = richTextBox1.Text + ("\n          Artist: " + finalgnAlbum.Artist.Name.Display);
                //    // richTextBox1.Text = richTextBox1.Text +("          Artist: " + finalgnAlbum..);
                //}
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + ("\nNo albums found for the input.");
            }
        }

        /*-----------------------------------------------------------------------------
		 *  SetFingerprintBeginWriteEnd
		 */
        //  private void
        //  SetFingerprintBeginWriteEnd(GnMusicId gnMusicID)
        //  {
        //      bool complete = false;

        //      FileInfo file = new FileInfo(txt_path.Text);

        //      using (BinaryReader b = new BinaryReader(File.Open(file.FullName, FileMode.Open, FileAccess.Read)))
        //      {
        //          b.BaseStream.Position = 0;

        //          /* skip the wave header (first 44 bytes). we know the format of our sample files*/
        //          b.BaseStream.Seek(44, SeekOrigin.Begin);

        //          byte[] audioData = b.ReadBytes(2048);


        //          gnMusicID.FingerprintBegin(GnFingerprintType.kFingerprintTypeFile, 44100, 16, 2);

        //          while (audioData.Length > 0)
        //          {
        //              complete = gnMusicID.FingerprintWrite(audioData, (uint)audioData.Length);
        //              if (true == complete)
        //                  break;
        //              else
        //                  audioData = b.ReadBytes(2048);
        //          }

        //          gnMusicID.FingerprintEnd();

        //          if (false == complete)
        //          {
        //              /* Fingerprinter doesn't have enough data to generate a fingerprint.
        //Note that the sample data does include one track that is too short to fingerprint. */
        //              richTextBox1.Text = richTextBox1.Text + ("\nWarning: input file does contain enough data to generate a fingerprint :" + file.FullName);
        //          }
        //      }
        //  }
        private void SetFingerprintBeginWriteEnd(GnMusicId gnMusicID)
        {
            // use NAudio.dll get file media information 
            using (var b = new MediaFoundationReader(txt_path.Text))
            {
                b.Position = 0;
                // Show total seconds 
                lbl_end.Text = b.TotalTime.TotalSeconds.ToString() + " (Seconds)";
                lbl_process.Text = "Processing...";
                button3.Visible = false;

                //Start FingerprintBegin for first time
                gnMusicID.FingerprintBegin(GnFingerprintType.kFingerprintTypeGNFPX, (uint)b.WaveFormat.SampleRate, (uint)b.WaveFormat.BitsPerSample, (uint)b.WaveFormat.Channels);

                //Get total bytes 
                int currentBytes = b.WaveFormat.AverageBytesPerSecond * (int)numericUpDown1.Value;

                //Create buffer data
                byte[] audioData = new byte[currentBytes + 1];

                // read data from mix 
                int bytesRead = b.Read(audioData, 0, currentBytes);

                // Start Looping
                SetFingerprintBeginWriteEndLoop(b, gnMusicID, audioData, bytesRead, currentBytes, b.Length, (int)numericUpDown1.Value);

                lbl_process.Text = "Completed...";
                button3.Visible = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"> Get WaveFormat</param>
        /// <param name="gnMusicID"></param>
        /// <param name="audioData"></param>
        /// <param name="bytesRead"></param>
        /// <param name="currentBytes"></param>
        /// <param name="maxLength"></param>
        /// <param name="index"></param>
        private void SetFingerprintBeginWriteEndLoop(MediaFoundationReader b, GnMusicId gnMusicID, byte[] audioData, int bytesRead, int currentBytes, long maxLength, int second)
        {
            try
            {
                bool complete = false;
                //Start FingerprintBegin for loop
                gnMusicID.FingerprintBegin(GnFingerprintType.kFingerprintTypeGNFPX, (uint)b.WaveFormat.SampleRate, (uint)b.WaveFormat.BitsPerSample, (uint)b.WaveFormat.Channels);
                while (currentBytes < maxLength)
                {
                    complete = gnMusicID.FingerprintWrite(audioData, (uint)bytesRead);
                    if (true == complete)
                    {
                        // encoding data
                        var getData = gnMusicID.FingerprintDataGet();

                        // get response from server
                        GnResponseAlbums response = gnMusicID.FindAlbums(getData, GnFingerprintType.kFingerprintTypeGNFPX);

                        //Display response
                        DisplayFindAlbumResutlsByFingerprint(response);

                        // end Fingerprint
                        gnMusicID.FingerprintEnd();
                        var totalRead = b.WaveFormat.AverageBytesPerSecond * second;
                        var seconds = currentBytes / b.WaveFormat.AverageBytesPerSecond;
                        richTextBox1.Text = richTextBox1.Text + ("\n Seconds : " + seconds);
                        currentBytes += bytesRead;
                        if ((currentBytes + totalRead) >= maxLength)
                        {
                            totalRead = (int)maxLength - (currentBytes);
                        }
                        else
                        {
                            var a = richTextBox1.Text;
                            // Skip currentBytes 
                            b.Seek(currentBytes, SeekOrigin.Begin);
                            audioData = new byte[totalRead + 1];
                            // Read bytes from file
                            bytesRead = b.Read(audioData, 0, totalRead);
                            // Loop
                            SetFingerprintBeginWriteEndLoop(b, gnMusicID, audioData, bytesRead, currentBytes, maxLength, second);
                            break;
                        }
                    }
                }

                if (false == complete)
                {
                    /* Fingerprinter doesn't have enough data to generate a fingerprint.
                        Note that the sample data does include one track that is too short to fingerprint. */
                    richTextBox1.Text = richTextBox1.Text + ("\nWarning: input file does contain enough data to generate a fingerprint :");
                }
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
            }


        }
        /*-----------------------------------------------------------------------------
		 *  MusicidFingerprintAlbum
		 */
        private void MusicidFingerprintAlbum(GnUser user)
        {
            richTextBox1.Text = richTextBox1.Text + ("\n*****Sample MID-Stream Query*****");

            try
            {
                GnMusicId gnMusicID = new GnMusicId(user);

                /* Set the input fingerprint*/
                SetFingerprintBeginWriteEnd(gnMusicID);

                /* Perform the search */
                //GnResponseAlbums response = gnMusicID.FindAlbums(gnMusicID.FingerprintDataGet(), GnFingerprintType.kFingerprintTypeFile);
                ////GnMusicIdFile midf = new GnMusicIdFile(user);
                ////richTextBox1.Text = richTextBox1.Text + ("\nPrinting results for " + midf.FileInfos.count() + " files:");
                ////midf.DoTrackId(GnMusicIdFileProcessType.kQueryReturnSingle, GnMusicIdFileResponseType.kResponseAlbums);
                ////richTextBox1.Text = richTextBox1.Text + ("\n");


                //DisplayFindAlbumResutlsByFingerprint(response);

            }
            catch (GnException e)
            {
                richTextBox1.Text = richTextBox1.Text + ("\nError Code           :: " + e.ErrorCode);
                richTextBox1.Text = richTextBox1.Text + ("\nError Description    :: " + e.ErrorDescription);
                richTextBox1.Text = richTextBox1.Text + ("\nError API            :: " + e.ErrorAPI);
                richTextBox1.Text = richTextBox1.Text + ("\nSource Error Code    :: " + e.SourceErrorCode);
                richTextBox1.Text = richTextBox1.Text + ("\nSourceE rror Module  :: " + e.SourceErrorModule);
            }
        }


        #endregion

        #region MusicIDFileTrackID

        /*
         *  Name: MusicIDFileTrackID.cs (MusicID-File TrackID sample appilcation)
         *  Description:
         *  TrackID processing provides the simplest processing of media files. With this method, MusicID-File processes
         *  each media file independently, without regard for any other provided media files.
         *  This method is best used for small sets of media recognition, where getting an answer is more important then
         *  getting the best answer. It is also appropriate to use for retrieving all possible results for a single media
         *  file. The GnMusicIdFile::DoTrackID method provides TrackID processing.
         *
         *  Command-line Syntax:
         *  sample clientId clientIdTag license gnsdkLibraryPath
         */
        void DoMusicIDFile(GnUser user, GnMusicIdFileProcessType processType, GnMusicIdFileResponseType responseType, string file)
        {
            /* Perform the Query */
            using (GnMusicIdFileEventsDelegate myMidEvents = new MusicIDFileEvents())
            {
                GnMusicIdFile midf = new GnMusicIdFile(user, myMidEvents);

                /* Add our sample files to the query. Metadata and fingerprints will be set in the callbacks. */
                // SetQueryData(midf);
                AddFile(midf, file);
                richTextBox1.Text = richTextBox1.Text + ("\nPrinting results for " + midf.FileInfos.count() + " files:");
                midf.DoTrackId(processType, responseType);
                richTextBox1.Text = richTextBox1.Text + ("\n");
            }

        }
        void AddFile(GnMusicIdFile midf, string filePath)
        {
            /* identifier string - we'll use the file path, which is unique */
            GnMusicIdFileInfo fileinfo = midf.FileInfos.Add(filePath);

            /* Set the file path in the fileinfo */
            fileinfo.FileName = filePath;

            /*Set fingerprint and metadata*/
            setFingerprint(fileinfo);
            setMetadata(fileinfo);
        }
        public static void DisplayAlbums(GnResponseAlbums response, GnMusicIdFileInfoStatus status)
        {
            int match = 0;
            if ((int)status == 4)
                richTextBox12.Text = richTextBox12.Text + ("\n\tSingle result.");
            else if ((int)status == 5)
                richTextBox12.Text = richTextBox12.Text + ("\n\tMultiple results.");

            richTextBox12.Text = richTextBox12.Text + ("\tAlbum count: " + response.Albums.count());
            GnAlbumEnumerable albumEnumerable = response.Albums;
            GnAlbumEnumerator albumEnumerator = albumEnumerable.GetEnumerator();
            while (albumEnumerator.hasNext())
            {
                GnAlbum album = albumEnumerator.next();
                GnTitle albTitle = album.Title;
                richTextBox12.Text = richTextBox12.Text + ("\n\tMatch " + ++match + " - Album title:\t\t" + albTitle.Display);
            }
        }

        /*-----------------------------------------------------------------------------
		 *  setMetadata
		 */
        private void setMetadata(GnMusicIdFileInfo fileinfo)
        {
            try
            {
                String identifier = fileinfo.Identifier;

                /*
				 * A typical use for this callback is to read file tags (ID3, etc) for the basic
				 * metadata of the track.  To keep the sample code simple, we went with .wav files
				 * and hardcoded in metadata for just one of the sample tracks.  (MYAPP_SAMPLE_FILE_5)
				 */

                /* So, if this isn't the correct sample track, return.*/
                if (!identifier.Contains("kardinal_offishall_01_3s.wav"))
                {
                    return;
                }
                fileinfo.AlbumArtist = "kardinal offishall";
                fileinfo.AlbumTitle = "quest for fire";
                fileinfo.TrackTitle = "intro";
            }
            catch (GnException ex)
            {
                richTextBox1.Text = richTextBox1.Text + ("Error while setting metadata setMetadata()" + ex.Message);
            }
        }

        /*-----------------------------------------------------------------------------
		 *  setFingerprint
		 */
        private void setFingerprint(GnMusicIdFileInfo fileInfo)
        {
            FileStream fileStream = null;
            try
            {
                bool complete = false;
                byte[] audioData = new byte[2048];
                int numRead = 0;

                string filename = fileInfo.FileName.ToString();
                //folderPath + 
                fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                /* check file for existence */
                if (fileStream == null || !fileStream.CanRead)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n\nError: Failed to open input file: " + filename);
                }
                else
                {
                    /* skip the wave header (first 44 bytes). we know the format of our sample files, but please
						be aware that many wav file headers are larger then 44 bytes! */
                    if (44 != fileStream.Seek(44, SeekOrigin.Begin))
                    {
                        richTextBox1.Text = richTextBox1.Text + ("\n\nError: Failed to seek past header: " + filename + "\n");
                    }
                    else
                    {
                        /* initialize the fingerprinter
							Note: Our sample files are non-standard 11025 Hz 16-bit mono to save on file size */
                        fileInfo.FingerprintBegin(11025, 16, 1);

                        numRead = fileStream.Read(audioData, 0, 2048);
                        while ((numRead) > 0)
                        {
                            /* write audio to the fingerprinter */
                            complete = fileInfo.FingerprintWrite(audioData, Convert.ToUInt32(numRead));

                            /* does the fingerprinter have enough audio? */
                            if (complete)
                            {
                                break;
                            }

                            numRead = fileStream.Read(audioData, 0, 2048);
                        }
                        fileStream.Close();

                        /* signal that we are done */
                        fileInfo.FingerprintEnd();
                        // Debug.WriteLine("Fingerprint: " + fileInfo.Fingerprint + " File: " + fileInfo.FileName);
                    }
                }
                if (!complete)
                {
                    /* Fingerprinter doesn't have enough data to generate a fingerprint.
						   Note that the sample data does include one track that is too short to fingerprint. */
                    richTextBox1.Text = richTextBox1.Text + ("Warning: input file does not contain enough data to generate a fingerprint:\n" + filename);
                }
            }
            catch (FileNotFoundException e)
            {
                richTextBox1.Text = richTextBox1.Text + ("FileNotFoundException " + e.Message);
            }
            catch (IOException e)
            {
                richTextBox1.Text = richTextBox1.Text + ("IOException " + e.Message);
            }
            finally
            {
                try
                {
                    fileStream.Close();
                }
                catch (IOException e)
                {
                    richTextBox1.Text = richTextBox1.Text + ("IOException " + e.Message);
                }
            }
        }
        /*-----------------------------------------------------------------------------
		 *  SetQueryData
		 */
        void SetQueryData(GnMusicIdFile midf)
        {
            List<string> filenames = new List<string>();

            filenames.Add(@"01_stone_roses.wav");
            filenames.Add(@"04_stone_roses.wav");
            filenames.Add(@"stone roses live.wav");
            filenames.Add(@"Dock Boggs - Sugar Baby - 01.wav");
            filenames.Add(@"kardinal_offishall_01_3s.wav");
            filenames.Add(@"Kardinal Offishall - Quest For Fire - 15 - Go Ahead Den.wav");

            /* add our 6 sample files to the query */
            foreach (string file in filenames)
            {
                AddFile(midf, file);
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            f_tracklist_compare frm = new f_tracklist_compare(listTrackMatched, listTrackMatchedArtist, listTrackMatchedCompare, listTrackMatchedAristCompare);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void f_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
