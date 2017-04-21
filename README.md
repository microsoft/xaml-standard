# XAML Standard

This repository contains the principles and definition of XAML Standard.

XAML Standard solves the markup/source code sharing problem for UI developers by bringing together a common definition of XAML APIs and schematic concepts across all platforms including mobile, desktop and others.
- XAML Standard is a vocabulary spec that defines the base set of APIs and schema concepts that all XAML based UI frameworks have to implement
- XAML Standard 1.0 will be implemented by Xamarin Forms and the Universal Windows Platform
- XAML Standard is not a library and does not implement the APIs defined. 
- Application developers continue to target the XAML UI frameworks and not the XAML Standard itself in order to create apps. For example: To create a XAML based iOS application, developers can target Xamarin.Forms (which in turn will be based on the XAML standard). 

## How to engage, contribute and provide feedback

This spec is being designed in the open. Currently proposed APIs can be located in the [Proposals] (docs/proposals) folder.
You are encouraged to start a discussion by filing an issue. 

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).

## Additional resources

Learn more about XAML Standard at [Introducing XAML Standard] (http://www.blogs.windows.com/buildingapps/) blog post. 

For more information, check out the [FAQ](docs/faq.md).
