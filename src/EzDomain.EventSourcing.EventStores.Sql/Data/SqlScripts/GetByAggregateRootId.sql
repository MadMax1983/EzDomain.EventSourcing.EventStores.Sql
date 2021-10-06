SELECT
    [e].[Version],
    [e].[AggregateRootId],
    [e].[Type],
    [e].[Data]
FROM [EventStore].[Events] [e]
WHERE [e].[AggregateRootId] = @AggregateRootId
AND [e].[Version] > @FromVersion