this is a small API project to manage user's watchlist,
there are 4 http methods:
- 1 GET /api/Content  method returns all movies based on the search word.
- 2 GET /api/WatchList method returns all the user's movies in hes/hers watchlist.
- 3 POST /api/WatchList method updates user's watchlist. method requires user id and content id.
- 4 PATCH /api/WatchList method updates content's has watched status.
