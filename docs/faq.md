# FAQs

## Additional resources
* [Introducing XAML Standard and .NET Standard 2.0 blog](https://blogs.windows.com/buildingapps/2017/05/19/introducing-xaml-standard-net-standard-2-0)
* [Ch9 Interview with Tim Heuer, Scott Hunter and Miguel de Icaza](https://developer.microsoft.com/en-us/windows/projects/events/build/2017/net-standard-20-uwp-support-and-ui-features)

## What is XAML Standard?
XAML Standard is a vocabulary specification that defines a standard XAML markup vocabulary. Frameworks that support XAML Standard can share common XAML based UI definitions. 

The goal is for the first version, XAML Standard 1.0, to be available later this year. Post specification plans include support of XAML standard in Xamarin.Forms and UWP.

## What is the relationship between XAML Standard, UWP, Xamarin.Forms?
* XAML Standard is the specification document that defines which APIs and schema concepts a XAML based framework needs to implement.
* UWP and Xamarin Forms are concrete frameworks that implement the XAML Standard. 

## What can I do with XAML Standard that I couldn’t do before?
We are at the beginning of a journey that makes it easy for you to reuse your XAML source files between Xamarin.Forms, UWP and even WPF to a large extent. For example - once XAML Standard is supported by Xamarin.Forms, you can use `<TextBlock/>` in your markup and have it supported in a Xamarin.Forms app targeting iOS and Android instead of needing to know and use `<Label/>` like you did before.

## What should I do if I develop UWPs or Xamarin.Forms apps today?
Nothing changes for existing developers - you can continue to use the same APIs you have always used in both frameworks. XAML Standard will help you reuse/share any common UI code that you wish to share between frameworks.

## Who decides what goes in the Standard?
We are starting with a small review board outlined [here](reviewboard.md). The principles behind what goes in the standard are outlined [here](reviewboard.md#principles).

## How can I participate?
We are in the early stages of defining the spec right now, you can see a draft of XAML Standard 1.0 getting defined [here](https://github.com/Microsoft/xaml-standard/blob/staging/docs/v1draft.md). We encourage you to start a discussion or give us direct feedback by [filing an issue](https://github.com/Microsoft/xaml-standard/issues) or [starting a proposal](https://github.com/Microsoft/xaml-standard/labels/proposal) for what you would like to see in v1 and beyond. Read the [proposals-faq](proposalsfaq.md) for more information.

