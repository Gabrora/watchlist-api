პროგრამა გაშვებისას დააგენერირებს user და content მონაცემებს ხოლო wishList ცარიელი იქნება გატესტვის მიზნით.(connectionString იქნება ჩასანაცვლებელი)
არის 4 http მეთოდი:
1 GET /api/Content მეთოდს გადაეცემა ფილმის სახელი ან სახელის ნაწილი და შედეგად აბრუნებს ყველა ფილმს რომელიც შეესაბამება შეყვანილ ინფორმაციას.
2 GET /api/WatchList მეთოდს გადაეცემა UserId, შედეგად აბრუნებს მაგ მომხმარებლის WishList-ს.
3 POST /api/WatchList მეთოდს გადაეცემა UserId და ContentId, შედეგად გადაცემულ User ს WatchList ში დაემატება გადაცემული კონტენტი.
4 PATCH /api/WatchList მეთოდს გადეცემა UserId და ContentId, შედეგად გადაცემული User ის WatchList ში ჩაიწერება რომ კონტენტი ნანახი აქვს.
არის გაკეთებული ვალიდაციები, რათა სწორად მოხდეს ინფორმაციის შენახვა მონაცემთა ბაზაში.
