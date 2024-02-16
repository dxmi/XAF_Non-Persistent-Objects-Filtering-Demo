<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T952649)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to filter and sort Non-Persistent Objects


When a [Non\-Persistent Object](https://docs.devexpress.com/eXpressAppFramework/116516/concepts/business-model-design/non-persistent-objects) collection contains many objects, it is often useful to filter it. However, the built-in filtering facilities are disabled for non-persistent collections by default.

## Implementation Details

To enable filtering and sorting for [Non\-Persistent Objects](https://docs.devexpress.com/eXpressAppFramework/116516/concepts/business-model-design/non-persistent-objects), use the built-in **DynamicCollection** class or a custom **DynamicCollectionBase** descendant.

Here, we create a **DynamicCollection** instance and pass it in the [NonPersistentObjectSpace\.ObjectsGetting](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.NonPersistentObjectSpace.ObjectsGetting) event handler. We subscribe to the **DynamicCollection.FetchObjects** event and pass a new collection of non-persistent objects every time the filtering or sorting parameters are changed. If you cannot filter the collection manually, set the **ShapeData** event parameter to *true*. Then, **DynamicCollection** will process data (filter, sort, trim) internally.

This example demonstrates two approaches to filter objects.

- *Contact* objects are filtered at the storage level. Criteria and Sorting values passed in event parameters are converted into a storage-specific format and used in arguments of the *DataTable.Select* method call. DataSet returns filtered and sorted data that is then transformed into non-persistent objects. This approach can be useful if data for non-persistent objects is obtained from a remote service, a custom database query or a stored procedure.

- *Article* objects are filtered and sorted by DynamicCollection internally. This functionality is enabled when the **ShapeData** parameter of the **DynamicCollection.FetchObjects** event is set to *true*. This approach is useful when all data is already available and no custom processing is required.

When **DynamicCollection** is used, the built-in [FullTextSearch Action](https://docs.devexpress.com/eXpressAppFramework/112997/concepts/filtering/full-text-search-action) is shown in corresponding non-persistent list views.

*FindArticlesController* in this example shows a custom search form with a lookup editor that allows filtering non-persistent objects in a lookup list view.


## Files to Review

- [Contact.cs](./CS/EFCore/NonPersistentFilteringEF/NonPersistentFilteringEF.Module/BusinessObjects/Contact.cs)
- [Article.cs](./CS/EFCore/NonPersistentFilteringEF/NonPersistentFilteringEF.Module/BusinessObjects/Article.cs )
- [NonPersistentObjectBase.cs](./CS/EFCore/NonPersistentFilteringEF/NonPersistentFilteringEF.Module/BusinessObjects/NonPersistentObjectBase.cs )
- [Module.cs](./CS/EFCore/NonPersistentFilteringEF/NonPersistentFilteringEF.Module/Module.cs )
- [FindArticlesController.cs](CS/EFCore/NonPersistentFilteringEF/NonPersistentFilteringEF.Module/Controllers/FindArticlesController.cs)

## Documentation

- [Non-Persistent Objects](https://docs.devexpress.com/eXpressAppFramework/116516/business-model-design-orm/non-persistent-objects)


## More Examples

- [How to implement CRUD operations for Non-Persistent Objects stored remotely in eXpressApp Framework](https://github.com/DevExpress-Examples/XAF_Non-Persistent-Objects-Editing-Demo)
- [How to edit Non-Persistent Objects nested in a Persistent Object](https://github.com/DevExpress-Examples/XAF_Non-Persistent-Objects-Nested-In-Persistent-Objects-Demo)
- [How to: Display a List of Non-Persistent Objects](https://github.com/DevExpress-Examples/XAF_how-to-display-a-list-of-non-persistent-objects-e980)
- [How to filter and sort Non-Persistent Objects](https://github.com/DevExpress-Examples/XAF_Non-Persistent-Objects-Filtering-Demo)
- [How to refresh Non-Persistent Objects and reload nested Persistent Objects](https://github.com/DevExpress-Examples/XAF_Non-Persistent-Objects-Reloading-Demo)
- [How to edit a collection of Persistent Objects linked to a Non-Persistent Object](https://github.com/DevExpress-Examples/XAF_Non-Persistent-Objects-Edit-Linked-Persistent-Objects-Demo)
