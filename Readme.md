<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/S131432/Form1.cs) (VB: [Form1.vb](./VB/S131432/Form1.vb))
* [Program.cs](./CS/S131432/Program.cs) (VB: [Program.vb](./VB/S131432/Program.vb))
<!-- default file list end -->
# How to apply the even/odd row appearance feature to each set of grouped rows separately


<p>When the appearance of even and odd rows is enabled, these rows are painted with different colors. By default, the GridView determines whether a row is even or odd based on the RowHandle. In this situation, if a group has odd row count, the first row of the next group will be considered as an odd row. If you want each group to always begin with an even row, you can manually implement this feature within the GridView.RowStyle event.</p>

<br/>


