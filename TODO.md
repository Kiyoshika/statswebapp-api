# TODO
My general TODO list in no particular order:
* add validation on filename and filesize on server side (in case end users try manipulating the client-side validations)
* get users public IP when creating new session. if they have an old session ID already, can dump any old files off the server tied to that old session ID.
* improve CSV parser (right now I used a very naive implementation)
  * Should support custom delimiters, delimiters within strings, empty cells
