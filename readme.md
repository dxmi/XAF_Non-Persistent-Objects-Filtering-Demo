*Files to look at*:

* [Contact.cs](./CS/NonPersistentObjectsDemo.Module/BusinessObjects/Contact.cs)
* [Article.cs](./CS/NonPersistentObjectsDemo.Module/BusinessObjects/Article.cs)
* [NonPersistentObjectBase.cs](./CS/NonPersistentObjectsDemo.Module/BusinessObjects/NonPersistentObjectBase.cs)
* [Module.cs](./CS/NonPersistentObjectsDemo.Module/Module.cs)


# How to filter and sort Non-Persistent Objects

## Scenario

When a [Non\-Persistent Object](https://docs.devexpress.com/eXpressAppFramework/116516/concepts/business-model-design/non-persistent-objects) colletion contains a lot of objects, it is often useful to filter it. However, the built-in filtering facilities are disabled for non-persistent collections by default.

## Solution

To enable filtering and sorting for [Non\-Persistent Objects](https://docs.devexpress.com/eXpressAppFramework/116516/concepts/business-model-design/non-persistent-objects), use the built-in **DynamicCollection** class or a custom **DynamicCollectionBase** descendant.

Create a **DynamicCollection** instance and pass it in the [NonPersistentObjectSpace\.ObjectsGetting](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.NonPersistentObjectSpace.ObjectsGetting) event handler. Subscribe to the **DynamicCollection.ObjectsGetting** event and pass a new collection of non-persistnet objects every time the filtering or sorting parameters are changed. If you cannot filter the collection manually, set the **ShapeRawData** event parameter to *true*. Then, **DynamicCollection** will process data (filter, sort, trim) internally.

This example demonstrates two approaches to filter objects.

- The *Contact* objects are filtered at the storage level. The Criteria and Sorting values passed in event parameters are converted to the storage-specific format and used in arguments of the DataSet.Select method call. The DataSet returns filtered and sorted data that is then transformed into non-persistent objects. This approach can be useful if data for non-persistent objects is obtained from a remote service, a custom database query or a stored procedure.

- The *Artice* objects are filtered and sorted by the DynamicCollection internally. This functionality is enabled when the **ShapeRawData** parameter of the **DynamicCollection.ObjectsGetting** event is set to *true*. This approach is useful when all data is already available and no custom processing is required.

When **DynamicCollection** is used, the built-in [FullTextSearch Action](https://docs.devexpress.com/eXpressAppFramework/112997/concepts/filtering/full-text-search-action) is shown in corresonding non-persistent list views.

The *FindArticlesController* in this example shows a custom search form with a lookup editor that allows filtering non-perssitent objects in a lookup list view.

Filtering and sorting at the data source level is also supported in Reports. Use the [Criteria](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.DataSourceBase.Criteria) and [Sorting](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.DataSourceBase.Sorting) properties of [CollectionDataSource](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.CollectionDataSource) to specify filter criteria and sorting parameters.

