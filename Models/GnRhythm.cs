
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
* \class GnRhythm
* Gracenote Rhythm provide a suite of Adaptive Radio and Recommendation features.
*
* Key features of Gracenote Rhythm:
*    - Creates highly-relevant and personalized adaptive radio experiences and recommendations for end-users
*    - Delivers radio stations or playlists from seed artist(s) and track(s)
*    - Radio stations respond to user's likes and dislikes and includes support for DMCA (Digital Millennium Copyright Act) sequencing rulesPerforms bulk audio track recognition
*/
public class GnRhythm : GnObject {
  private HandleRef swigCPtr;

  internal GnRhythm(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnRhythm_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnRhythm obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnRhythm() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnRhythm(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

/**
*  Retrieves the Rhythm library's version string.
*  <p><b>Remarks:</b></p>
*  This API can be called at any time, after getting instance of GnManager successfully.
*  The returned string is a constant. Do not attempt to modify or delete.
*
*  Example version string: 1.2.3.123 (Major.Minor.Improvement.Build)
*
*  Major: New functionality
*  Minor: New or changed features
*  Improvement: Improvements and fixes
*  Build: Internal build number
*/
  public static string Version() {
	IntPtr temp = gnsdk_csharp_marshalPINVOKE.GnRhythm_Version(); 
	return GnMarshalUTF8.StringFromNativeUtf8(temp);
}

/**
*  Retrieves the Rhythm library's build date string.
*  @return gnsdk_cstr_t Build date string of the format: YYYY-MM-DD hh:mm UTC
*  <p><b>Remarks:</b></p>
*  This API can be called at any time, after getting instance of GnManager successfully.
*  The returned string is a constant. Do not attempt to modify or delete.
*
*  Example build date string: 2008-02-12 00:41 UTC
*/
  public static string BuildDate() {
	IntPtr temp = gnsdk_csharp_marshalPINVOKE.GnRhythm_BuildDate(); 
	return GnMarshalUTF8.StringFromNativeUtf8(temp);
}

  public GnRhythm() : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythm(), true) {
  }

}

}
