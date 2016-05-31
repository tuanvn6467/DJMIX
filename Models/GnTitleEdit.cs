
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  @internal GnTitleEdit @endinternal
*  represents  GnTitle's information returned by Gracenote.
*/
public class GnTitleEdit : GnDataObject {
  private HandleRef swigCPtr;

  internal GnTitleEdit(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnTitleEdit_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnTitleEdit obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnTitleEdit() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnTitleEdit(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public void Language(GnListElement langElement) {
    gnsdk_csharp_marshalPINVOKE.GnTitleEdit_Language(swigCPtr, GnListElement.getCPtr(langElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  @internal Display @endinternal
*  Sets a list-based value by the list item Submit ID for display value. If the value does not
*   exist, it is added. If the value does exist, it is changed. If the role_submit_id is 0, the
*   value is deleted.
*  @param value set Value corresponding to the specified GnDataObject value key
*  <p><b>Remarks:</b></p>
*  Use this function to set a list-based Submit ID to display value, prior to adding the GnDataObject to a
*   parcel.
*/
  public string Display {
	/* csvarin typemap code */
	set 
	{
		IntPtr tempvalue = GnMarshalUTF8.NativeUtf8FromString(value);
		gnsdk_csharp_marshalPINVOKE.GnTitleEdit_Display_set(swigCPtr, tempvalue);
		GnMarshalUTF8.ReleaseMarshaledUTF8String(tempvalue);
	}
 
	get
	{   
		/* csvarout typemap code */
		return GnMarshalUTF8.StringFromNativeUtf8(gnsdk_csharp_marshalPINVOKE.GnTitleEdit_Display_get(swigCPtr) );
	} 

  }

  public string Sortable {
	/* csvarin typemap code */
	set 
	{
		IntPtr tempvalue = GnMarshalUTF8.NativeUtf8FromString(value);
		gnsdk_csharp_marshalPINVOKE.GnTitleEdit_Sortable_set(swigCPtr, tempvalue);
		GnMarshalUTF8.ReleaseMarshaledUTF8String(tempvalue);
	}
 
	get
	{   
		/* csvarout typemap code */
		return GnMarshalUTF8.StringFromNativeUtf8(gnsdk_csharp_marshalPINVOKE.GnTitleEdit_Sortable_get(swigCPtr) );
	} 

  }

  public GnTitle GnTitle {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTitleEdit_GnTitle_get(swigCPtr);
      GnTitle ret = (cPtr == IntPtr.Zero) ? null : new GnTitle(cPtr, true);
      return ret;
    } 
  }

}

}
