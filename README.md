# Xamarin-Forms-Shopping-Cart
Xamarin forms shopping cart by replacing toolbar item.

## Build Status
Platform  | Build status
------------- | -------------
Android build | [![Build Status](https://build.appcenter.ms/v0.1/apps/5a4a818c-0cb4-4be2-81ee-2fb7bc4775cd/branches/master/badge)](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart)   
iOS build | [![Build Status](https://build.appcenter.ms/v0.1/apps/8649f4ab-0a7f-4f3e-a3d2-863671de8558/branches/master/badge)](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart)

## Description
This code explaines how to add badge for the toolbar item using xamarin forms. Here it follows MVVM pattern. Persistence storage is done by using [Settings plugin](https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/Settings). [MVVM helpers](https://github.com/jamesmontemagno/mvvm-helpers) nuget is used.
Here default navigation bar is hidden and custom navigation bar is used, refer [this link](https://social.technet.microsoft.com/wiki/contents/articles/37733.xamarin-shopping-cart-counter-in-forms-navigation-bar.aspx) for more information.
Xamarin forms messaging center is used for presenting and hiding navigation drawer. [FFImageLoading](https://github.com/luberda-molinet/FFImageLoading) is used for image cashing and image loading placeholder. This code also explains simple chat user interface. 

Here cart page uses persistent storage, second page shows getting data from web service and displaying it in list view and third page uses local SQLite database to insert, edit, retrieve and delete records. 

This project uses [Visual Studio App Center](https://appcenter.ms/) for crash reporting and analytics, which require iOS and android App secret which need to be generated in app center and to be placed [here](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/ShoppingCarts/ShoppingCarts/Helpers/ApiKeys.cs). This project uses Visual Studio App Center builds, status of the builds will be shown in README.md file.

### Prerequisites
[Visual Studio 2019](https://visualstudio.microsoft.com/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/) with Xamarin.

### Development 
Clone this repository and open [ShoppingCarts.sln](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/ShoppingCarts.sln) with Visual Studio or Visual Studio for Mac.

### Built With
* [Visual Studio 2019](https://visualstudio.microsoft.com/) with Xamarin - IDE used
* [Visual Studio App Center](https://appcenter.ms/) - Build Management

## Screenshots
<p>
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/SideMenu.png" width="150" height="300" alt="SideMenu">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/ItemList.png" width="150" height="300" alt="ItemList">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/CartPageEmpty.png" width="150" height="300" alt="CartPageEmpty">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/CartPage.png" width="150" height="300" alt="CartPage">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/ItemDetail.png" width="150" height="300" alt="ItemDetail">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/RESTWebService.png" width="150"       height="300" alt="RESTWebService">
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/SQLiteDatabase.png" width="150" height="300" alt="SQLiteDatabase">  
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/ItemGallery.png" width="150" height="300" alt="ItemGallery">  
  <img src="https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/Screenshots/ChatPage.png" width="150" height="300" alt="ChatPage">  
</p>

## Authors

* **Leslie Correa** - *Contributor* - [LeslieCorrea](https://github.com/LeslieCorrea)


## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/LICENSE) file for details.

