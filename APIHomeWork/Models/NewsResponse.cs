using System;

namespace APIHomeWork.Models
{
    public class NewsResponse
    {
        //needa read json info and interpret it
        public string Status { get; set; } //status of the response, e.g., "ok" or "error"
        public int TotalResults { get; set; } //total number of results available
        public List<Article> Articles { get; set; } //list of articles returned by the API
    }

    public class Article        //need seperate class coz of the structure of the response givven by json
    {
        public Source Source { get; set; } //source of the article
        public string Author { get; set; } //author of the article
        public string Title { get; set; } //title of the article
        public string Description { get; set; } //description of the article
        public string Url { get; set; } //URL of the article
        public string UrlToImage { get; set; } //URL to the image associated with the article
        public DateTime PublishedAt { get; set; } //date and time when the article was published
        public string Content { get; set; } //content of the article

    }

    public class Source     //need seperate class coz of the structure of the response givven by json
    {
        public string Id { get; set; } //ID of the source, can be null
        public string Name { get; set; } //name of the source
    }






        //eg definition:
        //GET https://newsapi.org/v2/everything?q=Apple&from=2025-08-20&sortBy=popularity&apiKey=API_KEY

    //eg request:
    //curl https://newsapi.org/v2/everything -G \
    //-d q = Apple \
    //-d from = 2025 - 08 - 20 \
    //-d sortBy = popularity \
    //-d apiKey = 5594867e72ee4375a37f02922b32318f

    //eg response:
    /*
    "status": "ok",
    "totalResults": 460,
    -"articles": [
    -{
    -"source": {
    "id": "business-insider",
    "name": "Business Insider"
    },
    "author": "Jordan Hart",
    "title": "Flip phones are reigniting the smartphone wars",
    "description": "Apple's rumored 2026 foldable iPhone could transform the smartphone market, as Samsung and Motorola gain traction in the growing foldable segment.",
    "url": "https://www.businessinsider.com/samsung-bet-on-flip-phones-gains-momentum-against-apple-2025-8",
    "urlToImage": "https://i.insider.com/68a35b39cfc04e97619b93e5?width=1200&format=jpeg",
    "publishedAt": "2025-08-20T09:56:02Z",
    "content": "Apple is rumored to be getting in on the foldable trend in 2026.Jung Yeon-je / AFP via Getty Images\r\n<ul><li>Flippable and foldable phones are staging a comeback and shaking up the smartphone market.… [+2732 chars]"
    },
            */

}
