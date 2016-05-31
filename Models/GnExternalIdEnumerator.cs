/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

public class GnExternalIdEnumerator : System.Collections.Generic.IEnumerator<GnExternalId>, IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GnExternalIdEnumerator(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnExternalIdEnumerator obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnExternalIdEnumerator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnExternalIdEnumerator(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

			public bool
			MoveNext( )
			{
				return hasNext( );
			}

			public GnExternalId Current {
				get {
					return next( );
				}
			}
			object System.Collections.IEnumerator.Current {
				get {
					return Current;
				}
			}
			public void
			Reset( )
			{
			}

		
  public GnExternalId __ref__() {
    GnExternalId ret = new GnExternalId(gnsdk_csharp_marshalPINVOKE.GnExternalIdEnumerator___ref__(swigCPtr), false);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GnExternalId next() {
    GnExternalId ret = new GnExternalId(gnsdk_csharp_marshalPINVOKE.GnExternalIdEnumerator_next(swigCPtr), true);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool hasNext() {
    bool ret = gnsdk_csharp_marshalPINVOKE.GnExternalIdEnumerator_hasNext(swigCPtr);
    return ret;
  }

  public uint distance(GnExternalIdEnumerator itr) {
    uint ret = gnsdk_csharp_marshalPINVOKE.GnExternalIdEnumerator_distance(swigCPtr, GnExternalIdEnumerator.getCPtr(itr));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GnExternalIdEnumerator(GnExternalIdProvider provider, uint pos) : this(gnsdk_csharp_marshalPINVOKE.new_GnExternalIdEnumerator(GnExternalIdProvider.getCPtr(provider), pos), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
