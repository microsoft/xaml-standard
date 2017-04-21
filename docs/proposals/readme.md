# XAML Standard proposals

XAML Standard proposals are living documents describing the current thinking about a XAML feature/API. This is being maintained with similar intent to [C# Language proposals](https://github.com/dotnet/csharplang/tree/master/proposals). 

Proposals can be either *active*, *inactive*, *rejected* or *done*. *Active* proposals are stored directly in the proposals folder, *inactive* and *rejected* proposals are stored in the [inactive](proposals/inactive) and [rejected](proposals/rejected) subfolders, and *done* proposals are archived in a folder corresponding to the standard version they are part of.

## Lifetime of a proposal

A proposal starts its life when the [XAML Standard review board](docs/review-board) decides that it might make a good addition to the Standard some day. Typically it will start out being *active*, but if we want to capture an idea without wanting to work on it right now, a proposal can also start out in the *inactive* subfolder. Proposals may even start out directly in the *rejected* state, if we want to make a record of something we don't intend to do. For instance, if a popular and recurring request is not possible to implement, we can capture that as a rejected proposal.

A proposal is *active* if it is moving forward through design. Once it is completely *done*, i.e. the feature has been completely specified, it is moved into a subdirectory corresponding to its [version](docs/versions).

If a proposal turns out not to be likely to make it into the Standard at all, e.g. because it proves unfeasible, does not seem to add enough value or just isn't right for the Standard, it will be [rejected](proposals/rejected). If a proposal has reasonable promise but is not currently being prioritized to specify, it may be declared [inactive](proposals/inactive) to avoid cluttering the main folder. It is perfectly fine for work to happen on inactive or rejected proposals, and for them to be resurrected later. The categories are there to reflect current design intent.

## Nature of a proposal

A proposal should follow the [proposal template](proposal-template.md). A good proposal should:

- Fit with the general spirit and aesthetic of the XAML Standard.
- Not introduce subtly alternate syntax for existing features.
- Add a lot of value for a clear set of users.
- Not add significantly to the complexity of the XAML Standard, especially for new users.  

## Discussion of proposals

Feedback and discussion happens in [proposal issues](https://github.com/Microsoft/xaml-standard/labels/proposal). When a new proposal is added to the proposals folder, it should be announced in a proposal issue by the proposal author. 

 
