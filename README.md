# XAML Standard : a set of principles that drive XAML dialect alignment

## Updates: 
_We appreciate the continued passion for aligning XAML dialects.  This repo defines the set of principles that drive XAML dialect alignment and those principles are known as “XAML Standard”. At this point, the principles are set and therefore we do not expect more updates to this repo._
 
## Principles: 

* Different platforms have different personalities and capabilities. For the best end-user experience, developers build native apps that embrace the native personalities and capabilities of the platforms and device form factors.  
* **Xamarin** and **Xamarin.Forms** are optimized for developers building native mobile scenarios and focuses on exposing the common and abstracted subset of controls and capabilities most needed by mobile developers.
* **Windows 10 XAML** and **WPF** are optimized for native Windows experiences and focuses on exposing the full and unique capabilities of the Windows platform.  Developers empowered with **Windows 10 XAML** and **WPF**, can harness the full and unique capabilities of the Windows platform, including the most rich and demanding experiences optimized for use with mouse, keyboard and touch.
* We will continue to optimize **Xamarin.Forms** as an abstraction layer for native mobile development and optimize **Windows 10 XAML** and **WPF** for Windows native experiences. XAML Standard is an alignment effort targeted at finding the right middle ground of concepts and tags that can be shared between Microsoft’s XAML UI systems to make it easier to work with XAML regardless of target platforms.

## Revised definition and scope: 

* XAML Standard is set of principles that drive XAML dialect alignment and not a product or product feature. 

## Timeframe: 
As a first phase of alignment, we are making a set of additive updates to Windows 10 XAML and Xamarin.Forms. For example: 
* TextBlock, StackPanel (and several other tags as requested here) are being added to Xamarin.Forms - see [aka.ms/xf-xamlstandard](<https://aka.ms/xf-xamlstandard>) for details on how you can try these out. 
* Similarly ease of use APIs like StackPanel.Spacing etc., are being added to Windows 10 XAML. 

For the full list of aligned tags at this time, see [here](docs/v1draft.md).

If you have further feedback on XAML alignment, please provide that on either the UWP XAML uservoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform) or the [Xamarin.Forms community forums](https://developercommunity.visualstudio.com/spaces/8/index.html)

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).
