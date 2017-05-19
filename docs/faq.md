# FAQs

## Why XAML?
Designers and Developers occupy a variety of different toolsets to create their intended experiences for users with a variety of dynamic variables in mind; such as screen sizes, touch dimensions, 2D and 3D entities, animation(s) etc. XAML is about bridging the gap between these two worlds by ensuring both platforms and tooling can agree on a standard based vocabulary. The intent and philosophy of XAML is to remove areas where compromise is enforced due to platform limitations and/or tooling export functionality.

## What is XAML Standard?
XAML Standard is a vocabulary specification that defines a standard XAML markup vocabulary. Frameworks that support XAML Standard can share common XAML based UI definitions. 

The goal is for the first version, XAML Standard 1.0, to be available later this year. Post specification plans include support of XAML standard.

## What is the relationship between XAML Standard, UWP, Xamarin.Forms?
* XAML Standard is the specification document that defines which APIs and schema concepts a XAML based framework needs to implement.
* UWP and Xamarin Forms are concrete frameworks that implement the XAML Standard. 

## What can I do with XAML Standard that I couldn’t do before?
We are at the beginning of a journey that makes it easy for you to reuse your XAML source files between platforms and tooling. The focus is primarily on bringing the old up to an agreed standard whilst focusing on the new to adhere to a new standard. For example - inside XAML standard focus on `<TextBlock/>` that would later translate into platform implementations (`<Label/>`) is abstracted from the original author(s).

## What should I do if I develop UWPs or Xamarin.Forms apps today?
Nothing changes for existing developers - you can continue to use the same APIs you have always used in both frameworks. XAML Standard will help you reuse/share any common UI code that you wish to share between frameworks. 

## What should I do if I develop WPF and/or Silverlight still today?
Monitor the proposed standard carefully, look at ways in which the standard could be retrofitted via component/control development to help move you closer to adhering to its likely implementation. Retroactively upgrading WPF to fit the proposed standard is unlikely, however once the standard retains a calm state it will enable you a more structured roadmap on what to do next with existing applications designed in the WPF/Silverlight platforms.

## How can I participate?
We are in the early stages of defining the spec right now, you can see a draft of XAML Standard 1.0 getting defined [here](https://github.com/Microsoft/xaml-standard/blob/staging/docs/v1draft.md). We encourage you to start a discussion or give us direct feedback by [filing an issue](https://github.com/Microsoft/xaml-standard/issues) or [starting a proposal](https://github.com/Microsoft/xaml-standard/labels/proposal) for what you would like to see in v1 and beyond.
