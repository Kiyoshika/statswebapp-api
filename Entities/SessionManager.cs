using System.Collections.Generic;
using System;

namespace statswebapp_api
{
  // barebones session manager to generate IDs for different clients
  public class SessionManager
  {
    static private List<Guid> sessionIDs = new();

    // perform naive linear search. this application is
    // small scale so this should be sufficient for now
    static private bool SessionIDExists(Guid sessionID)
    {
      foreach (Guid _sessionID in sessionIDs)
        if (_sessionID.Equals(sessionID))
          return true;
      return false;
    }

    static public Guid GenerateSessionID()
    {
      // generate IDs until we find a unique one
      Guid newSessionID = Guid.NewGuid();
      while (SessionIDExists(newSessionID))
        newSessionID = Guid.NewGuid();
      return newSessionID;
    }
  }
};