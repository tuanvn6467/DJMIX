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

public class GnMatchEnumerable : System.Collections.Generic.IEnumerable<GnMatch>, IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GnMatchEnumerable(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnMatchEnumerable obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnMatchEnumerable() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnMatchEnumerable(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

			System.Collections.Generic.IEnumerator<GnMatch> System.Collections.Generic.IEnumerable<GnMatch> .GetEnumerator( )
			{
				return GetEnumerator( );
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.
			    GetEnumerator( )
			{
				return GetEnumerator( );
			}

		
  public GnMatchEnumerable(GnMatchProvider provider, uint start) : this(gnsdk_csharp_marshalPINVOKE.new_GnMatchEnumerable(GnMatchProvider.getCPtr(provider), start), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public GnMatchEnumerator GetEnumerator() {
    GnMatchEnumerator ret = new GnMatchEnumerator(gnsdk_csharp_marshalPINVOKE.GnMatchEnumerable_GetEnumerator(swigCPtr), true);
    return ret;
  }

  public GnMatchEnumerator end() {
    GnMatchEnumerator ret = new GnMatchEnumerator(gnsdk_csharp_marshalPINVOKE.GnMatchEnumerable_end(swigCPtr), true);
    return ret;
  }

  public uint count() {
    uint ret = gnsdk_csharp_marshalPINVOKE.GnMatchEnumerable_count(swigCPtr);
    return ret;
  }

  public GnMatchEnumerator at(uint index) {
    GnMatchEnumerator ret = new GnMatchEnumerator(gnsdk_csharp_marshalPINVOKE.GnMatchEnumerable_at(swigCPtr, index), true);
    return ret;
  }

  public GnMatchEnumerator getByIndex(uint index) {
    GnMatchEnumerator ret = new GnMatchEnumerator(gnsdk_csharp_marshalPINVOKE.GnMatchEnumerable_getByIndex(swigCPtr, index), true);
    return ret;
  }

}

}
