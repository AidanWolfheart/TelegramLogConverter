# Telegram Log Converter

This application converts JSON files that are exported via Telegram into a more printable text document.

## Configuration

The configuration file includes certain types of keys which values can be modified to produce a more customised output file. Note: LogResultFormat only supports {date}, {from} & {text} tags.

| Key                        | Default Value             | Description                                              |
|----------------------------|---------------------------|----------------------------------------------------------|
| LogResultFormat            | "[{date}] {from}: {text}" | Order in which output text would appear                  |
| LogName                    | "TelegramLog_"            | Prefix of the output file name                           |
| TimestampFormat            | "dd-MM-yyyy-HH-mm-ss"     | Format of the output file name timestamp if it's included|
| IncludeTimestampInName     | "true"                    | Whether timestamp should be included in output file name |


