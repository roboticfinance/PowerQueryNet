let
    //Source = Excel.Workbook(File.Contents("C:\Users\chha\Documents\repo\PowerQueryNet\Samples\PowerQueryParameters\MyExcel\4-财务报表表样.xlsx"), null, true),
    Source = AzureStorage.Blobs("https://synapse4cdm.blob.core.windows.net/excels/"),
    #"https://synapse4cdm blob core windows net/excels/_4-财务报表表样 xlsx" = Source{[#"Folder Path"="https://synapse4cdm.blob.core.windows.net/excels/",Name="4-财务报表表样.xlsx"]}[Content],
    #"Imported Excel Workbook" = Excel.Workbook(#"https://synapse4cdm blob core windows net/excels/_4-财务报表表样 xlsx"),
    Table1_Table = #"Imported Excel Workbook"{[Item=TableName,Kind="Table"]}[Data],
    //Table1_Table = Source{[Item=TableName,Kind="Table"]}[Data] ,
    #"Changed Type" = Table.TransformColumnTypes(Table1_Table,{{"资        产asset", type text}, {"年初数", type number}, {"期末数", type number}}),
    #"Filtered Rows" = Table.SelectRows(#"Changed Type", each ([资        产asset] <> null)),
    #"Added Conditional Column" = Table.AddColumn(#"Filtered Rows", "Custom", each if not Text.StartsWith([资        产asset], " ") then [资        产asset] else null),
    #"Filled Down" = Table.FillDown(#"Added Conditional Column",{"Custom"}),
    #"Renamed Columns" = Table.RenameColumns(#"Filled Down",{{"Custom", "Level1"}}),
    #"Added Conditional Column1" = Table.AddColumn(#"Renamed Columns", "Custom", each if Text.StartsWith([资        产asset], " ") then [资        产asset] else null),
    #"Split Column by Delimiter" = Table.SplitColumn(#"Added Conditional Column1", "Custom", Splitter.SplitTextByEachDelimiter({"    "}, QuoteStyle.Csv, false), {"Custom.1", "Custom.2"}),
    #"Changed Type1" = Table.TransformColumnTypes(#"Split Column by Delimiter",{{"Custom.1", type text}, {"Custom.2", type text}}),
    #"Removed Columns" = Table.RemoveColumns(#"Changed Type1",{"Custom.1"}),
    #"Renamed Columns1" = Table.RenameColumns(#"Removed Columns",{{"Custom.2", "Level2"}}),
    #"Filtered Rows1" = Table.SelectRows(#"Renamed Columns1", each ([Level2] <> null)),
    #"Removed Columns1" = Table.RemoveColumns(#"Filtered Rows1",{"资        产asset"}),
    #"Reordered Columns" = Table.ReorderColumns(#"Removed Columns1",{"Level1", "Level2", "年初数", "期末数"}),
    #"Replaced Value" = Table.ReplaceValue(#"Reordered Columns",null,0,Replacer.ReplaceValue,{"年初数"}),
    #"Replaced Value1" = Table.ReplaceValue(#"Replaced Value",null,0,Replacer.ReplaceValue,{"期末数"})
in
    #"Replaced Value1"