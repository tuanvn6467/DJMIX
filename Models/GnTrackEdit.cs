
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
*  @internal GnTrackEdit @endinternal
*  represents  Track's information returned by Gracenote.
*/
public class GnTrackEdit : GnDataObject {
  private HandleRef swigCPtr;

  internal GnTrackEdit(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnTrackEdit_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnTrackEdit obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnTrackEdit() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnTrackEdit(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public GnCreditEdit Credit(uint ord) {
    GnCreditEdit ret = new GnCreditEdit(gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Credit(swigCPtr, ord), true);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Mood(GnListElement moodElement) {
    gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Mood(swigCPtr, GnListElement.getCPtr(moodElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Tempo(GnListElement tempoElement) {
    gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Tempo(swigCPtr, GnListElement.getCPtr(tempoElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Genre(GnListElement genreElement) {
    gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Genre(swigCPtr, GnListElement.getCPtr(genreElement));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  @internal Year @endinternal
*  Sets a list-based value by the list item Submit ID for YEAR. If the value does not
*   exist, it is added. If the value does exist, it is changed. If the role_submit_id is 0, the
*   value is deleted.
*  @param value set Value corresponding to the specified GnDataObject value key
*  <p><b>Remarks:</b></p>
*  Use this function to set a list-based Submit ID to YEAR, prior to adding the GnDataObject to a
*   parcel.
*/
  public string Year {
	/* csvarin typemap code */
	set 
	{
		IntPtr tempvalue = GnMarshalUTF8.NativeUtf8FromString(value);
		gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Year_set(swigCPtr, tempvalue);
		GnMarshalUTF8.ReleaseMarshaledUTF8String(tempvalue);
	}
 
	get
	{   
		/* csvarout typemap code */
		return GnMarshalUTF8.StringFromNativeUtf8(gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Year_get(swigCPtr) );
	} 

  }

/**
*  @internal getArtistEdit @endinternal
*  Create an empty object of GnArtistEdit using ARTIST.
*  @return GnArtistEdit
*/
  public GnArtistEdit Artist {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Artist_get(swigCPtr);
      GnArtistEdit ret = (cPtr == IntPtr.Zero) ? null : new GnArtistEdit(cPtr, true);
      return ret;
    } 
  }

/**
*  @internal CreditAdd @endinternal
*  Create an empty object of GnCreditEdit using CREDIT.
*  @return GnCreditEdit
*/
  public GnCreditEdit CreditAdd {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTrackEdit_CreditAdd_get(swigCPtr);
      GnCreditEdit ret = (cPtr == IntPtr.Zero) ? null : new GnCreditEdit(cPtr, true);
      return ret;
    } 
  }

/**
*  @internal getWorkEdit @endinternal
*  Create an empty object of GnAudioWorkEdit using AUDIO WORK.
*  @return GnAudioWorkEdit
*/
  public GnAudioWorkEdit AudioWork {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTrackEdit_AudioWork_get(swigCPtr);
      GnAudioWorkEdit ret = (cPtr == IntPtr.Zero) ? null : new GnAudioWorkEdit(cPtr, true);
      return ret;
    } 
  }

/**
*  @internal getTitleEdit @endinternal
*  Create an empty object of GnTitleEdit using TITLE OFFICIAL.
*  @return GnTitleEdit
*/
  public GnTitleEdit Title {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTrackEdit_Title_get(swigCPtr);
      GnTitleEdit ret = (cPtr == IntPtr.Zero) ? null : new GnTitleEdit(cPtr, true);
      return ret;
    } 
  }

  public GnTrack GnTrack {
    get {
      IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnTrackEdit_GnTrack_get(swigCPtr);
      GnTrack ret = (cPtr == IntPtr.Zero) ? null : new GnTrack(cPtr, true);
      return ret;
    } 
  }

}

}
