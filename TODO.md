# TODO
My general TODO list in no particular order:
* get users public IP when creating new session. if they have an old session ID already, can dump any old files off the server tied to that old session ID.
* redesign `DatasetRepository` to be a bit more efficient. Can use a hashmap with the session ID as a key, then have a static array of datasets to iterate over. Each client will be limited to 10 uploads at a time so a static-sized array should work fine.
* improve CSV parser (right now I used a very naive implementation)
  * Should support custom delimiters, delimiters within strings, empty cells
