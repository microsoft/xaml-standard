# XAML Standard Review Board
We need a XAML Standard review board. We make the following proposal:

- **Universal Windows Platform - XAML team representatives**. The rationale here is that most, if not all, of the APIs that are part of XAML Standard are implemented and evolved by the UWP-XAML team
- **Xamarin.Forms representatives**. Xamarin.Forms are a platform vendor and have their own implementation. Similar to UWP-XAML, most of the APIs in XAML Standard are implemented and evolved by Xamarin.Forms to target iOS and Android. While they mostly compile to native implementations, API changes and extensions can impact their ability to support the XAML Standard. Thus, we need to coordinate any changes with them.

Please note that this list isn't meant to be closed: as more platform vendors and API drivers appear, the review board will expand accordingly.

## Reviews

Decisions made by the review board will be made public and posted here.

## Principles
Not every XAML API needs to be part of the XAML Standard. The following principles should be applied in determining what will and will not be a part of the standard

* **Ubiquitous APIs** In order to enable a vibrant XAML based ecosystem, it's important to have a common vocabulary of types that XAML developers can rely on. Thus, it's beneficial to add widely used APIs to the XAML Standard as it simplifies building reusable markup/code.

* **Common denominator APIs** The XAML Standard represents the lowest common denominator that can be built upon with specialized frameworks for targeting different end points.
  * Highly divergent concepts can be part of individual frameworks.
  * Any API or concept that is fundamentally tied to a specific native implementation/technology will be excluded from the standard. For example: A Windows Hello based login control will not be part of XAML Standard.
  * Frameworks can add to what is prescribed by the XAML Standard. For example: XAML Standard Slider definition does not include an Orientation property. UWP implementation of XAML Standard can include that to be a super-set.

* While the standard does not mandate how the APIs are implemented (for now), it is expected that the frameworks respect the most intuitive and common behavior of the API while implementing the same. For example: 'Grid.RowSpan=”2”' must do the same thing across all frameworks that implement the standard and expose Grid.RowSpan property.
  * This will be honored within reason – pixel perfect matching across UI frameworks is not expected. There may be some behavior differences and edge cases falling under a gray area of convergence and that is allowed as long as 90% of cases are close to the spec.

* The Standard may have annotations that allow types or P/M/Es to be optional. In these cases, the expectation is that they will be ignored by the frameworks that do not support them (they will not cause “unsupported” exceptions). 
 

