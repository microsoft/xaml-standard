# XAML Standard Review Board
We are starting with the following proposal for a XAML Standard review board. 

- **Universal Windows Platform - XAML team representatives**. The rationale here is that most, if not all, of the APIs that are part of XAML Standard are implemented and evolved by the UWP-XAML team
- **Xamarin.Forms representatives**. Xamarin.Forms are a platform vendor and have their own implementation. Similar to UWP-XAML, most of the APIs in XAML Standard are implemented and evolved by Xamarin.Forms to target iOS and Android. While they mostly compile to native implementations, API changes and extensions can impact their ability to support the XAML Standard. Thus, we need to coordinate any changes with them.

For XAML Standard 1.0 - the primary goal is to unify the dialects between UWP and Xamarin.Forms. So, for the most part, the decision maker is Microsoft with input on what is desired from the broader community here. 

Going forward, we want to expand the review board as we grow: as more platform vendors and API drivers appear, and as we get more implementers of the standard, we will grow this review board as well. 

## Principles
Not every XAML API needs to be part of the XAML Standard. The following principles will be applied in determining what will and will not be a part of the standard. 

* **Widely used APIs** In order to enable a vibrant XAML based ecosystem, it's important to have a common vocabulary of the most widely used types that XAML developers can comfortably rely on. XAML Standard will include such widely used APIs to enable maximum reuse.

* **Ubiquitous APIs** The XAML Standard represents the unified common subset of XAML that is universal to all platforms and could be made available everywhere.
  * Any API or concept that is fundamentally tied to a specific native implementation/technology will be excluded from the standard. For example: A Windows Hello based login control will not be part of XAML Standard.
  * Frameworks can add to what is prescribed by the XAML Standard. For example: XAML Standard Slider definition may not include an Orientation property. UWP XAML implementation of Slider can include that and be a super-set of XAML Standard.

* While the standard does not mandate how the APIs are implemented, it is expected that the frameworks respect the most intuitive and common behavior of the API while implementing the same in order for XAML developers to be able to reasonably reuse their markup. For example: 'Grid.RowSpan=”2”' must do the expected thing across all frameworks that implement the standard and expose Grid.RowSpan property.
  * This will be honored within reason – the Standard will not impose pixel perfect behavior matching across all XAML based UI frameworks.

* The Standard may have annotations that allow types or P/M/Es to be optional. In these cases, the expectation is that they will be ignored by the frameworks that do not support them (they will not cause “unsupported” exceptions). 
 

