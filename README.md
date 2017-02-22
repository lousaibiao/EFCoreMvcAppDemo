# EFCoreMvcAppDemo

***1234序号没有排列成功，就先用点来代替了***

**第一个** 运行起来的dotnet core mvc application。

主要有以下几点：

- 通过几个命令安装需要用的package

  > Install-Package Microsoft.EntityFrameworkCore.SqlServer

  > Install-Package Microsoft.EntityFrameworkCore.Tools –Pre

  > Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design

  > Scaffold-DbContext "Server=.;Database=Test;uid=sa;pwd=123456;Trusted_Connection=True;" "Microsoft.EntityFrameworkCore.SqlServer"

- 注册DbContext组件
```
public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();
    // Depedency Injection DbContext - TestContext
    services.AddDbContext<TestContext>(optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
}
```
- 给DbContext添加构造函数
```
public TestContext(DbContextOptions options) : base(options)
{
}
  ```
- 给DbContext添加构造函数
```
public class HomeController : Controller
{
    private readonly TestContext _dbContext;
    public HomeController(TestContext context)
    {
        this._dbContext = context;
    }
    public IActionResult Index()
    {
        var rst = _dbContext.Employee.ToList();
        return View(rst);
    }
}
```
