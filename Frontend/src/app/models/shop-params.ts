export class ShopParams {
  CategoryId = 0;
  Brandsid = 0;
  MaxPageSize = 10;
  pageSize = 5;
  pageIndex = 0;
  search = '';
  sort = 'name';
}

/*

private const int MaxPageSize = 10; // Max size for pages
private int pageSize = 5; // Default for Pages
private int pageIndex = 0; // Default PageIndex

public int PageSize
{
    get { return pageSize; }
    set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
}

public int PageIndex
{
    get { return pageIndex; }
    set { pageIndex = value >= 0 ? value : 0; }
}

private string? search;
public string? Search
{
    get { return search; }
    set { search = value?.ToLower(); }
}

public string? Sort { get; set; }
public int? Brandsid { get; set; }
public int? CategoryId { get; set; }

*/