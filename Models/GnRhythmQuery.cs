
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
* \class GnRhythmQuery
* Provides services for generating Rhythm Recommendations
*/
public class GnRhythmQuery : GnRhythm {
  private HandleRef swigCPtr;

  internal GnRhythmQuery(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnRhythmQuery obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnRhythmQuery() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnRhythmQuery(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

/**
*  Constructs a Rhythm query object with a Gracenote user and event delegate
*  @param user          [in] Set GnUser object representing the user making the GnMusicId request
*  @param pEventHandler [in-opt] Set Optional status event handler to get bytes sent, received, or completed.
*/
  public GnRhythmQuery(GnUser user, GnStatusEventsDelegate pEventHandler) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmQuery__SWIG_0(GnUser.getCPtr(user), GnStatusEventsDelegate.getCPtr(pEventHandler)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public GnRhythmQuery(GnUser user) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmQuery__SWIG_1(GnUser.getCPtr(user)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  Adds a Seed to the GnRhythmQuery object.
*  @param seed			[in] GnDataObject to be used as seed, can be a GnTrack, GnAlbum, or GnArtist object
*/
  public void AddSeed(GnDataObject seed) {
    gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_AddSeed(swigCPtr, GnDataObject.getCPtr(seed));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/** 
*  Generates a set of recommendations based on seeds set into the query handle.
*  @return An instance of GnResponseAlbums, response contains one Album per Recommended Track. 
*  <p><b>Remarks:</b></p>
*  The Matched Track on each Album in the GnResponseAlbums is the Recommended Track
*/
  public GnResponseAlbums GenerateRecommendations() {
    GnResponseAlbums ret = new GnResponseAlbums(gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_GenerateRecommendations(swigCPtr), true);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

/**
* Get the event handler provided on construction
* @return Event handler
*/
  public GnStatusEventsDelegate EventHandler() {
    IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_EventHandler(swigCPtr);
    GnStatusEventsDelegate ret = (cPtr == IntPtr.Zero) ? null : new GnStatusEventsDelegate(cPtr, false);
    return ret;
  }

/**
* Get GnRhythmQuery options object. Use to configure your GnRhythmQuery instance.
* @return Options object
*/
  public GnRhythmQueryOptions Options() {
    GnRhythmQueryOptions ret = new GnRhythmQueryOptions(gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_Options(swigCPtr), false);
    return ret;
  }

/**
* Set cancel state
* @param bCancel 	[in] Cancel state
*/
  public virtual void SetCancel(bool bCancel) {
    gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_SetCancel(swigCPtr, bCancel);
  }

/**
* Get cancel state.
* @return Cancel state
*/
  public virtual bool IsCancelled() {
    bool ret = gnsdk_csharp_marshalPINVOKE.GnRhythmQuery_IsCancelled(swigCPtr);
    return ret;
  }

}

}
