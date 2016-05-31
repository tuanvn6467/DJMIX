
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  @internal GnContributorEdit @endinternal
*  represents  GnContributor's information returned by Gracenote.
*/
public class GnContributorEdit : GnDataObject {
  private HandleRef swigCPtr;

  internal GnContributorEdit(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnContributorEdit_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnContributorEdit obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnContributorEdit() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnContributorEdit(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public void Genre(GnListElement genreElement) {
    gnsdk_csharp_marshalPINVOKE.GnContributorEdit_Genre(swigCPtr, GnListElement.getCPtr(genreElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Origin(GnListElement originElement) {
    gnsdk_csharp_marshalPINVOKE.GnContributorEdit_Origin(swigCPtr, GnListElement.getCPtr(originElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Era(GnListElement eraElement) {
    gnsdk_csharp_marshalPINVOKE.GnContributorEdit_Era(swigCPtr, GnListElement.getCPtr(eraElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void ArtistType(GnListElement arttypeElement) {
    gnsdk_csharp_marshalPINVOKE.GnContributorEdit_ArtistType(swigCPtr, GnListElement.getCPtr(arttypeElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public GnContributor GnContributor {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnContributorEdit_GnContributor_get(swigCPtr);
      GnContributor ret = (cPtr == IntPtr.Zero) ? null : new GnContributor(cPtr, true);
      return ret;
    } 
  }

}

}
