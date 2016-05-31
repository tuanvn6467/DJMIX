
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  @internal GnCreditEdit @endinternal
*  represents GnCredit's information returned by Gracenote.
*/
public class GnCreditEdit : GnDataObject {
  private HandleRef swigCPtr;

  internal GnCreditEdit(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnCreditEdit_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnCreditEdit obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnCreditEdit() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnCreditEdit(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public void Role(GnListElement roleElement) {
    gnsdk_csharp_marshalPINVOKE.GnCreditEdit_Role(swigCPtr, GnListElement.getCPtr(roleElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  @internal getNameOfficialEdit @endinternal
*  Create an empty object of GnNameEdit using NAME OFFICIAL.
*  @return GnNameEdit
*/
  public GnNameEdit Name {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnCreditEdit_Name_get(swigCPtr);
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
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnCreditEdit_Contributor_get(swigCPtr);
      GnContributorEdit ret = (cPtr == IntPtr.Zero) ? null : new GnContributorEdit(cPtr, true);
      return ret;
    } 
  }

  public GnCredit GnCredit {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnCreditEdit_GnCredit_get(swigCPtr);
      GnCredit ret = (cPtr == IntPtr.Zero) ? null : new GnCredit(cPtr, true);
      return ret;
    } 
  }

}

}
