namespace BookingApplication.Helpers;

// Possible solution to Editing objects.

public static class EntityUpdaterHelper
{
    public static T UpdateEntity<T>(T entity, object updateRequest)
        where T : class
    {
        var entityType = entity.GetType();
        var requestType = updateRequest.GetType();

        foreach (var prop in requestType.GetProperties())
        {
            var entityProp = entityType.GetProperty(prop.Name);
            if (entityProp != null && entityProp.CanWrite)
            {
                var newValue = prop.GetValue(updateRequest);
                if (newValue != null) // Only update non-null values
                {
                    entityProp.SetValue(entity, newValue);
                }
                // Should it update empty string?
            }
        }
        return entity;
    }
}
