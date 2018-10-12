# Xamarin-Forms-Shopping-Cart
Xamarin forms shopping cart by replacing toolbar item.

## Build status
Platform  | Build status
------------- | -------------
Android build | [![Build Status](https://build.appcenter.ms/v0.1/apps/5a4a818c-0cb4-4be2-81ee-2fb7bc4775cd/branches/master/badge)](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart)   
iOS build | [![Build Status](https://build.appcenter.ms/v0.1/apps/8649f4ab-0a7f-4f3e-a3d2-863671de8558/branches/master/badge)](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart)

This code explaines how to add badge for the toolbar item using xamarin forms. Here it follows MVVM pattern. Persistence storage is done by using [Settings plugin](https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/Settings). [MVVM helpers](https://github.com/jamesmontemagno/mvvm-helpers) nuget is used.
Here default navigation bar is hidden and custom navigation bar is used, refer [this link](https://social.technet.microsoft.com/wiki/contents/articles/37733.xamarin-shopping-cart-counter-in-forms-navigation-bar.aspx) for more information.
Xamarin forms messaging center is used for presenting and hiding navigation drawer. [FFImageLoading](https://github.com/luberda-molinet/FFImageLoading) is used for image cashing and image loading placeholder.

Here cart page uses persistent storage, second page shows getting data from web service and displaying it in list view and third page uses local SQLite database to insert, edit, retrieve and delete records. 

This project uses [Visual Studio App Center](https://appcenter.ms/) for crash reporting and analytics, which require iOS and android App secret which need to be generated in app center and to be placed [here](https://github.com/LeslieCorrea/Xamarin-Forms-Shopping-Cart/blob/master/ShoppingCarts/ShoppingCarts/Helpers/ApiKeys.cs). This project uses Visual Studio App Center builds, status of the builds will be shown in README.md file.

