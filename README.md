# BannerFlow Backend
Conform to CRUD restful api standard.
All method answers with correct Http Status codes and error handling 
Implementation was tested with Postman.

HTTP GET - Read method       
HTTP Post - Create method
HTTP PUT - Update method 
HTTP DELETE- DELETE Method

HTTP GET {LocalHost}/api/Banners : Gets all banner in list format\
HTTP GET {LocalHost}/api/Banners/{int:id} : Gets specific banner object\
HTTP POST {LocalHost}/api/Banners BODY - JsonObject : Creates banner and store in memory database, only html string needs to be specified.\
HTTP DELETE {LocalHost}/api/Banners/{int:id} : Deletes specified banner\
HTTP PUT {LocalHost}/api/Banners/{int:id} : Updates specified banner\
HTTP GET {LocalHost}/api/Banners/html/{int:id} : renders correct HTML view from Banners html code in browser\



