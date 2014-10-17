csharp-instagram-wrapper
========================

# C# SDK for Instagram API
It's C# wrapper to use Instagram API.

# Create new Application
Register your application on [Instagram Develpers](http://instagram.com/developer/).
While creating your app you must provide a redirect url. During the development application you can host your application on localhost

# Authentacion
[Instagram Authentacion Document](http://instagram.com/developer/authentication/)
If you are developing a web application create a Sign in Link
<pre>
https://instagram.com/oauth/authorize/?client_id=CLIENT-ID&redirect_uri=REDIRECT-URI&response_type=token<br>
<a href="https://instagram.com/oauth/authorize/?client_id=CLIENT-ID&redirect_uri=REDIRECT-URI&response_type=token">Sign in wit Instagram</a></pre>
For other type porjects (win form, store app or win phone) use web browser component and redicet login url.


# Permissions
<i>However, if you plan on asking for extended access such as liking, commenting, or managing friendships, you’ll have to specify these scopes in your authorization request. Here are the scopes we currently support:</i>
+ `basic`: - to read any and all data related to a user (e.g. following/followed-by lists, photos, etc.) (granted by default)
+ `comments` - to create or delete comments on a user’s behalf
+ `relationships` - to follow and unfollow users on a user’s behalf
+ `likes` - to like and unlike items on a user’s behalf
 add scope parameter in your sign in url: scope=likes+comments
 
 # Receiving Access Token
 After user signed in your application you'll get a code to get access token on redirect url. <pre>http://your-redirect-uri?code=CODE</pre>
 It's easy to get an access token via C# SDK.
 <pre>
InstagramAuth ia = new InstagramAuth();
InstaConfig ic = new InstaConfig();
ic.redirect_uri = ""; your app redirect url
ic.client_secret = ""; your app secret
ic.client_id = ""; //your app client id
var user = ia.GetAccessToken(code,ic); // get user who loged in with an access_token
 </pre>
 
Keep Development Alive PayPal cagri058@hotmail.com
