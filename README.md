# XAML Standard

## Updates: 
_Thank you for patiently bearing with us as we have been iterating over feedback and working to better define the principles for XAML Standard._
 
## Principles: 

* Different platforms have different personalities and capabilities.  For the best end-user experience, developers build native apps that embrace the native personalities and capabilities of the platforms and device form factors.  
* **Xamarin** and **Xamarin.Forms** are optimized for developers building native mobile scenarios and focuses on exposing the common and abstracted subset of controls and capabilities most needed by mobile developers.
* **Windows 10 XAML** and **WPF** are optimized for native Windows experiences and focuses on exposing the full and unique capabilities of the Windows platform.  Developers empowered with **Windows 10 XAML** and **WPF**, can harness the full and unique capabilities of the Windows platform, including the most rich and demanding experiences optimized for use with mouse, keyboard and touch.
* We will continue to optimize **Xamarin.Forms** as an abstraction layer for native mobile development and optimize **Windows 10 XAML** and **WPF** for Windows native experiences.  

## Revised definition and scope: 

* XAML Standard is an alignment effort targeted at finding the right middle ground of concepts and tags that can be shared between Microsoft’s XAML UI systems to make it easier to work with XAML regardless of target platforms.
* XAML Standard is set of principles that drive XAML dialect alignment and not a product or product feature.  For more details on the updated principles, see [Principles](docs/reviewboard.md#principles)

## Timeframe: 
As a first phase of alignment, we are making a set of additive updates to Windows 10 XAML and Xamarin.Forms. For example: 
* TextBlock, StackPanel (and several other tags as requested here) are being added to Xamarin.Forms - see [aka.ms/xf-xamlstandard](<https://aka.ms/xf-xamlstandard>) for details on how you can try these out. 
* Similarly ease of use APIs like StackPanel.Spacing etc., are being added to Windows 10 XAML. 

For the full list of aligned tags at this time, see [here](docs/v1draft.md).

With this clarified stance, we will be more active on the Issues and help provide more clarity on the goals and timelines. We encourage you to continue providing us feedback on concepts and tags that would benefit from closer alignment to serve your scenarios.

For more information, read the [faqs](docs/faq.md).

## How to engage, contribute and provide feedback

We encourage you to start a discussion or give us direct feedback by [filing an issue](https://github.com/Microsoft/xaml-standard/issues) or [starting a proposal](https://github.com/Microsoft/xaml-standard/labels/proposal). 

### _If you are posting an API for XAML standard consideration:_
- Mark it with the label: "proposal". 
- Add a brief overview of what you are proposing and why it belongs in XAML Standard alignment effort (in keeping with the principles of the effort).
- Provide a clear usecase/scenario that describes how this API benefits in sharing across XAML UI platforms, preferably a scenario from your experience or application that clearly illustrates why a control/API would benefit from being aligned.
- Add a brief example in XAML syntax for your proposal.
- Provide links to issues/discussions where this proposal has been talked about as well as any other pointer to where this originated or got discussed that could describe the motivation.

See [proposals-faq](docs/proposalsfaq.md) for more information.

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).
