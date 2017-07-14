﻿using System;
using Microsoft.ApplicationInsights.Channel;

namespace Microsoft.ApplicationInsights.Metrics.Extensibility
{
    public interface IMetricDataSeriesAggregator
    {
        DateTimeOffset PeriodStart { get; }
        DateTimeOffset PeriodEnd { get; }
        bool IsCompleted { get; }
        MetricDataSeries DataSeries { get; }

        bool SupportsRecycle { get; }
        bool TryRecycle();
        
        void Initialize(DateTimeOffset periodStart, IMetricValueFilter valueFilter);
        ITelemetry CompleteAggregation(DateTimeOffset periodEnd);
        ITelemetry CreateAggregateUnsafe(DateTimeOffset periodEnd);

        void TrackValue(uint metricValue);
        void TrackValue(double metricValue);
        void TrackValue(object metricValue);
    }
}
