
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  Collection of matches from a Scan & Match query
*/
public class GnResponseMatches : GnDataObject {
  private HandleRef swigCPtr;

  internal GnResponseMatches(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnResponseMatches_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnResponseMatches obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnResponseMatches() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnResponseMatches(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public GnMatchEnumerable Matches {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnResponseMatches_Matches_get(swigCPtr);
      GnMatchEnumerable ret = (cPtr == IntPtr.Zero) ? null : new GnMatchEnumerable(cPtr, true);
      return ret;
    } 
  }

}

}
