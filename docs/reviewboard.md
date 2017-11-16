# XAML Standard Review Board
The primary goal is alignment of dialects between Microsoft XAML UI systems. Hence, the decision maker is Microsoft with input on what is desired from the broader community here. The review board at this time includes representatives from **Windows10 XAML** and **Xamarin.Forms** teams.

## Principles
* XAML Standard is an alignment effort targeted at finding the right middle ground of concepts and tags that can be shared between Microsoft’s XAML UI systems (Windows10 XAML, WPF and Xamarin.Forms)
* XAML Standard is set of principles that drive XAML dialect alignment and not a product or product feature.

Not every XAML API needs to be part of the XAML Standard effort. The following principles will be applied in determining what will and will not be a part of the alignment effort. 

* **Widely used APIs** In order to enable a vibrant XAML based ecosystem, it's important to have a common vocabulary of the most widely used tags that XAML developers can comfortably rely on. The XAML Standard effort will include such widely used APIs to enable maximum reuse.

* **Ubiquitous APIs** The XAML Standard effort represents the unified common subset of XAML tags and concepts that is universal to all platforms and could be made available everywhere without compromising on enabling native user experiences.
  * Any API or concept that does not empower building of native mobile and desktop user experiences will be excluded from the standard effort. For example: Button.Content allowing any UI content will not be part of the alignment effort since such a content model is not native to iOS and Android Button control models.
  * Any API or concept that is fundamentally tied to a specific native implementation/technology will be excluded from the standard effort. For example: A Windows Hello based login control will not be part of XAML Standard.
  * Frameworks can add to what is prescribed by the XAML Standard. For example: XAML Standard Slider definition may not include an Orientation property. Windows10 XAML implementation of Slider can include that.

* While the standard effort does not mandate how the APIs are implemented, it is expected that the frameworks respect the most intuitive and common behavior of the API while implementing the same in order for XAML developers to be able to reasonably rely on definitions. For example: 'Grid.RowSpan=”2”' must do the expected thing across all frameworks that support the standard.
  * This will be honored within reason – the Standard effort will not impose pixel perfect behavior matching across all XAML based UI frameworks.
 

