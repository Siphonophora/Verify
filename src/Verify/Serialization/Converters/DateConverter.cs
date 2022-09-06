﻿#if NET6_0_OR_GREATER
class DateConverter :
    WriteOnlyJsonConverter<DateOnly>
{
    public override void Write(VerifyJsonWriter writer, DateOnly value)
    {
        if (writer.serialization.TryConvert(writer.Counter, value, out var result))
        {
            writer.WriteRawValueIfNoStrict(result);
            return;
        }

        writer.WriteRawValueWithScrubbers(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }
}
#endif