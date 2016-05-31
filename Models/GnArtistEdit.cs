
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  @internal GnArtistEdit @endinternal
*  represents  Artist's information returned by Gracenote.
*/
public class GnArtistEdit : GnDataObject {
  private HandleRef swigCPtr;

  internal GnArtistEdit(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnArtistEdit_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnArtistEdit obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnArtistEdit() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnArtistEdit(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

/**
*  @internal getNameOfficialEdit @endinternal
*  Create an empty object of GnNameEdit using NAME OFFICIAL.
*  @return GnNameEdit
*/
  public GnNameEdit Name {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnArtistEdit_Name_get(swigCPtr);
      GnNameEdit ret = (cPtr == IntPtr.Zero) ? null : new GnNameEdit(cPtr, true);
      return ret;
    } 
  }

/**
*  @internal getContributorEdit @endinternal
*  Create an empty object of GnContributorEdit using CONTRIBUTOR.
*  @return GnContributorEdit
*/
  public GnContributorEdit Contributor {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnArtistEdit_Contributor_get(swigCPtr);
      GnContributorEdit ret = (cPtr == IntPtr.Zero) ? null : new GnContributorEdit(cPtr, true);
      return ret;
    } 
  }

  public GnArtist GnArtist {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnArtistEdit_GnArtist_get(swigCPtr);
      GnArtist ret = (cPtr == IntPtr.Zero) ? null : new GnArtist(cPtr, true);
      return ret;
    } 
  }

}

}
