# Non-Persistent Objects Filtering Demo

This example demonstrates filtering and sorting capabilities provided by the [NonPersistentObjectSpace](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.NonPersistentObjectSpace) and **DynamicCollection** classes.

To support these operations for your non-persistent objects, create a **DynamicCollection** instance and pass it in the [NonPersistentObjectSpace\.ObjectsGetting](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.NonPersistentObjectSpace.ObjectsGetting) event handler. Subscribe to the **DynamicCollection.ObjectsGetting** event and pass a new collection of non-persistnet objects every time the filtering or sorting parameters are changed.

The *Contact* objects in this example are filtered at the storage level. The Criteria and Sorting values passed in event parameters are converted to the storage-specific format and used in arguments of the DataSet.Select method call. The DataSet returns filtered and sorted data that is then transformed into non-persistent objects. This approach can be useful if data for non-persistent objects is obtained from a remote service, a custom database query or a stored procedure.

The *Artice* objects in this example are filtered and sorted by the DynamicCollection internally. This functionality is enabled when the **ShapeRawData** parameter of the **DynamicCollection.ObjectsGetting** event is set to *true*. This approach is useful when all data is already available and no custom processing is required.

The built-in [FullTextSearch Action](https://docs.devexpress.com/eXpressAppFramework/112997/concepts/filtering/full-text-search-action) is shown in non-persistent list views when **DynamicCollection** is used.

The *FindArticlesController* in this example shows a custom search form with a lookup editor that allows filtering non-perssitent objects in a lookup list view.

Filtering and sorting at the data source level is also supported in Reports. Use the [Criteria](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.DataSourceBase.Criteria) and [Sorting](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.DataSourceBase.Sorting) properties of [CollectionDataSource](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ReportsV2.CollectionDataSource) to specify filter criteria and sorting parameters.

