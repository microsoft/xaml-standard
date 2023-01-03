# XAML Standard : a set of principles that drive XAML dialect alignment

## Updates: 
**03-JAN-2023: 
This repo is being archived.** The focus of aligning the XAML dialect across a number of our XAML-based languages was our initial goal. We were unable to find a direct alignment with our product areas as we’d hoped. To that end, we are choosing to archive this repo. Our frameworks such as [Windows Presentation Foundation (WPF)](https://learn.microsoft.com/dotnet/desktop/wpf/overview/?view=netdesktop-6.0), [WinAppSDK](https://learn.microsoft.com/windows/apps/windows-app-sdk/), and [.NET MAUI](https://learn.microsoft.com/dotnet/maui/what-is-maui?view=net-maui-7.0) are rich with features powerful for each use case and can leverage XAML declarative markup unique to their own scenarios and underlying platforms they serve. We will continue to evolve those frameworks as appropriate, enabling developers choosing those platforms for their apps to be most successful in their developer scenarios and targets.
 
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

If you have further feedback on XAML alignment, please provide that on either the [UWP XAML uservoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform) or the [Xamarin.Forms community forums](https://developercommunity.visualstudio.com/spaces/8/index.html)

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).
