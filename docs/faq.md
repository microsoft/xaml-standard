# FAQs

## Additional resources
* **NEW!!** [Xamarin.Forms - XAML Standard preview](https://developer.xamarin.com/guides/xamarin-forms/xaml/standard/) 
* [Introducing XAML Standard and .NET Standard 2.0 blog](https://blogs.windows.com/buildingapps/2017/05/19/introducing-xaml-standard-net-standard-2-0)
* [.NET Standard 2.0, UWP support and UI futures, Ch9 Interview with Tim Heuer, Scott Hunter and Miguel de Icaza](https://channel9.msdn.com/Events/Build/2017/C9L13)

## What is XAML Standard?
XAML Standard is an alignment effort to improve productivity for developers creating UI with Windows10 XAML and Xamarin.Forms. It is targeted at finding the right middle ground of concepts and tags that can be shared between Microsoft’s XAML UI systems - Windows10 XAML, WPF and Xamarin.Forms to make it easier to work with XAML regardless of target platforms.

## What is the relationship between XAML Standard, Windows10 XAML, WPF and Xamarin.Forms?
* XAML Standard is set of principles that drive XAML dialect alignment and not a product or product feature.  
* Windows10 XAML, WPF and Xamarin Forms are concrete frameworks that implement the XAML Standard. 
* We will continue to optimize Xamarin.Forms as an abstraction layer for native mobile development and optimize Windows 10 XAML and WPF for Windows native experiences

## What can I do after XAML Standard that I couldn’t do before?
We are at the beginning of a journey that makes it easy for you to align concepts between Xamarin.Forms, Windows10 XAML and even WPF to a large extent. For example - once Phase1 of XAML Standard is supported by Xamarin.Forms, you can use `<TextBlock/>` in your markup and have it supported in a Xamarin.Forms app targeting iOS and Android instead of needing to know and use `<Label/>` like you did before.

## What should I do if I develop Windows10, WPF or Xamarin.Forms apps today?
Nothing changes for existing developers - you can continue to use the same APIs you have always used in all three frameworks. The XAML Standard effort will help you reuse some of the common UI tags and concepts between Microsoft's XAML UI frameworks that were previously misaligned.

## Where can I try this out?
XAML Standard is not a product, but an alignment effort we are embarking on. 
* Windows10 Fall creators update included newly aligned properties in Windows10 XAML to match some Xamarin.Forms affordances.
* Check out [aka.ms/xf-xamlstandard](<https://aka.ms/xf-xamlstandard>) for a preview of newly aligned tags in Xamarin.Forms to match Windows10 XAML.

## Who decides what goes in the Standard?
The feedback and proposals from this repo are inputs into the overall decision making process. We are starting with a small review board outlined [here](reviewboard.md). The principles behind what goes in the standard are outlined [here](reviewboard.md#principles).

## How can I participate?
 We encourage you to start a discussion or give us direct feedback by [filing an issue](https://github.com/Microsoft/xaml-standard/issues) or [starting a proposal](https://github.com/Microsoft/xaml-standard/labels/proposal) for what you would like to see aligned. Read the [proposals-faq](proposalsfaq.md) for more information.

