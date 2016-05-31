
namespace GracenoteSDK {

using System;
using System.Runtime.InteropServices;

/**
* \class GnRhythmStation
* Provides services for interacting with Rhythm Stations
*/
public class GnRhythmStation : GnRhythm {
  private HandleRef swigCPtr;

  internal GnRhythmStation(IntPtr cPtr, bool cMemoryOwn) : base(gnsdk_csharp_marshalPINVOKE.GnRhythmStation_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GnRhythmStation obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GnRhythmStation() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          gnsdk_csharp_marshalPINVOKE.delete_GnRhythmStation(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

/**
*  Constructs a Rhythm Station object from a GnRhythmQuery object and event delegate
*  @param rhythmQuery   [in] GnRhythmQuery object containing the seeds and options to generate a new Rhythm Station.
*  @param pEventHandler [in-opt] Set Optional status event handler to get bytes sent, received, or completed.
*/
  public GnRhythmStation(GnRhythmQuery rhythmQuery, GnStatusEventsDelegate pEventHandler) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmStation__SWIG_0(GnRhythmQuery.getCPtr(rhythmQuery), GnStatusEventsDelegate.getCPtr(pEventHandler)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public GnRhythmStation(GnRhythmQuery rhythmQuery) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmStation__SWIG_1(GnRhythmQuery.getCPtr(rhythmQuery)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  Constructs a Rhythm Station object from an existing Rhythm Station ID, with a Gracenote user and event delegate
*  @param station_id    [in] An Rhythm Station ID which will be used to retrieve a pre-existing Rhythm Station.
*  @param user          [in] Set GnUser object representing the user making the GnMusicId request.
*  @param pEventHandler [in-opt] Set Optional status event handler to get bytes sent, received, or completed.
*/
  public GnRhythmStation(string station_id, GnUser user, GnStatusEventsDelegate pEventHandler) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmStation__SWIG_2(station_id, GnUser.getCPtr(user), GnStatusEventsDelegate.getCPtr(pEventHandler)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

  public GnRhythmStation(string station_id, GnUser user) : this(gnsdk_csharp_marshalPINVOKE.new_GnRhythmStation__SWIG_3(station_id, GnUser.getCPtr(user)), true) {
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
*  Retrieves the station ID
*   @return A C String contaning the Rhythm Station's ID.
*  <p><b>Remarks:</b></p>
*  The returned string is a constant. Do not attempt to modify or delete.
*/
  public string StationId() {
    string ret = gnsdk_csharp_marshalPINVOKE.GnRhythmStation_StationId(swigCPtr);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

/**
*  Generate a Rhythm Station Playlist.
*  @return An instance of GnResponseAlbums, response contains one Album per Recommended Track. 
*  <p><b>Remarks:</b></p>
*  The Matched Track on each Album in the GnResponseAlbums is the Recommended Track
*/
  public GnResponseAlbums GeneratePlaylist() {
    GnResponseAlbums ret = new GnResponseAlbums(gnsdk_csharp_marshalPINVOKE.GnRhythmStation_GeneratePlaylist(swigCPtr), true);
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

/**
*  Adds an event to a Rhythm station.
*   @param event        [in] One of the predefined Rhythm event types
*   @param gnObj        [in] A GnDataObject representing the context of the event
*/
  public void Event(GnRhythmEvent arg0, GnDataObject gnObj) {
    gnsdk_csharp_marshalPINVOKE.GnRhythmStation_Event(swigCPtr, (int)arg0, GnDataObject.getCPtr(gnObj));
    if (gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Pending) throw gnsdk_csharp_marshalPINVOKE.SWIGPendingException.Retrieve();
  }

/**
* Get the event handler provided on construction
* @return Event handler
*/
  public GnStatusEventsDelegate EventHandler() {
    IntPtr cPtr = gnsdk_csharp_marshalPINVOKE.GnRhythmStation_EventHandler(swigCPtr);
    GnStatusEventsDelegate ret = (cPtr == IntPtr.Zero) ? null : new GnStatusEventsDelegate(cPtr, false);
    return ret;
  }

/**
* Get GnRhythmQuery options object. Use to configure your GnRhythmQuery instance.
* @return Options object
*/
  public GnRhythmQueryOptions Options() {
    GnRhythmQueryOptions ret = new GnRhythmQueryOptions(gnsdk_csharp_marshalPINVOKE.GnRhythmStation_Options(swigCPtr), false);
    return ret;
  }

/**
* Set cancel state
* @param bCancel 	[in] Cancel state
*/
  public virtual void SetCancel(bool bCancel) {
    gnsdk_csharp_marshalPINVOKE.GnRhythmStation_SetCancel(swigCPtr, bCancel);
  }

/**
* Get cancel state.
* @return Cancel state
*/
  public virtual bool IsCancelled() {
    bool ret = gnsdk_csharp_marshalPINVOKE.GnRhythmStation_IsCancelled(swigCPtr);
    return ret;
  }

}

}
