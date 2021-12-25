
 
<h1 align="center"><img align="left" height="100px" src="https://user-images.githubusercontent.com/68722157/138828506-f58b7c57-5e10-4178-8f7d-5d5e12050113.png"> Yi框架-一个紧跟时代的.NetCore开源框架</h1>
<h1 align="center">基于.NET6+Vue快速开发框架</h1>
<h4 align="center">意义为了开发更简易</h4>

[English](README-en.md) | 简体中文

![sdk](https://img.shields.io/badge/sdk-6.0.1-d.svg)![License MIT](https://img.shields.io/badge/license-Apache-blue.svg?style=flat-square)

****
#### 简介:
**中文：意框架**

**CC.Yi.Old**：.Net5早期三层单体架构（已被CC.Yi取代）

**CC.Yi**:.Net5经典极简三层WebApi单体应用架构

**Yi.Framework.Net5**:.Net5 DDD领域驱动设计分层微服务架构

**Yi.Framework.Net6**:.Net6 DDD领域驱动设计分层微服务架构（正在更新）

**Yi.Vue**：Vue2.0配合CC.Yi.Framework使用前端项目（正在更新）

**分支：ec**：**Yi.Framework.Net5+vue2.0** 实战项目！基于 Yi.Framework.Net5 微服务千万级并发电商项目DEMO（同步更新）

**分支：erp**：**Yi.Framework.Net6+vue2.0** 实战项目！基于 Yi.Framework6 云管理系统项目DEMO（同步更新）

****

#### 演示地址：

废话少说直接上地址，**请不要**更改里面的数据

API服务： [yi.ccnetcore.com](http://yi.ccnetcore.com)     管理员账号：admin 、 123

![image](https://user-images.githubusercontent.com/68722157/147379813-f18b8e28-5c7f-4cd1-a93a-8ba3028424b1.png)


网关地址：[gate.ccnetcore.com/swagger](http://gate.ccnetcore.com/swagger)

![image](https://user-images.githubusercontent.com/68722157/147379797-0f8fb455-d072-414d-a9d7-ad717dd34357.png)


#### 支持:

- [x] 完全支持单体应用架构
- [x] 完全支持分布式应用架构
- [x] 完全支持微服务架构
- [ ] 即将支持网格服务架构（我们将在后续版本加入dapr）

****
#### 软件架构:

**架构**：后端.NET6(Asp.NetCore 6)与.NET5(Asp.NetCore 5)、前端Vue（2.0）

**关系型数据库**：mysql、sql server、sqlite、oracle

**操作系统**：Windows、Linux

**身份验证**：Identity、JWT、IdentityServer4

**组件**：EFcore、Autofac、Castle、Swagger、Log4Net、Redis、RabbitMq、ES、Quartz.net、T4

**分布式**：CAP、Lock

**微服务**：Consul、Ocelot、IdentityService、Apollo、Docker、Jenkins、Nginx、K8s、ELK、Polly

**封装**：Json处理模块，滑动验证码模块，base64图片处理模块，异常捕捉模块、邮件处理模块、linq封装模块、随机数模块、统一接口模块、基于策略的jwt验证、过滤器、数据库连接、跨域、初始化种子数据、Base32、Console输出、日期处理、文件传输、html筛选、http请求、ip过滤、md5加密、Rsa加密、序列化、雪花算法、字符串处理、编码处理、地址处理、xml处理、心跳检查

****
#### 支持模块:

大致如图：

![image](https://user-images.githubusercontent.com/68722157/142923071-2fa524eb-e833-4143-a926-51566e56e889.png)
![image](https://user-images.githubusercontent.com/68722157/142923150-ebe1b538-c3fc-42dd-bea8-83e10e0f819a.png)
![image](https://user-images.githubusercontent.com/68722157/142923529-e4fbb2f6-def1-4702-b9da-5adbd22f0a2f.png)


- [x] 支持`DDD领域驱动设计`进行分层，支持微服务扩展
- [x] 支持采用`异步`开发awit/async
- [x] 支持数据库主从`读写分离`
- [x] 支持功能替换，无需改动代码，只需配置`json文件`进行装配即可
- [x] 支持采用DbFirst开发方式，使用`T4模板代码生成器`，自动映射模型一键生成Service及IService所有代码
- [x] 支持`用户-角色-菜单-接口`以及vue2.0前端全部逻辑代码，下载无需修改直接使用
- [x] 支持`Aop封装`，FilterAop、IocAop、LogAop
- [x] 支持`Log4Net日志`记录，自动生成至bin目录下的logs文件夹
- [x] 支持`DbSeed数据库种子数据`接入，默认创建admin用户，密码123
- [x] 支持主流`数据库随意切换`，Mysql/Sqlite/Sqlserver/Oracle
- [x] 支持微软官方`EFcore ORM`
- [x] 支持`SwaggerWebAPI`，jwt身份认证接入
- [x] 支持`Cors`跨域
- [x] 支持`AutoFac`自动映射依赖注入   
- [x] 支持`consul`健康检查
- [x] 支持`RabbitMQ`消息队列
- [x] 支持`Redis`多级缓存 
- [x] 支持`Ocelot`网关，路由、服务聚合、服务发现、认证、鉴权、限流、熔断、缓存、Header头传递
- [x] 支持`Apollo`全局配置中心;
- [x] 支持`docker`镜像制作
- [x] 支持页面`静态化处理`，将动态页面生成静态页面
- [x] 支持`Quartz.net`任务调度，实现任意接口被调度
- [x] 支持`ELK`，log4net+kafka+es+logstach+kibana
- [x] 支持`IdentityService4`授权中心
- [x] 支持`Es`分词查询
- [x] 支持多级`缓存`
- [x] 支持`CAP`分布式事务，mysql+rabbitMq
- [x] 支持`Docker+k8s`部署
- [x] 支持`Jenkins+CI/CD`
- [x] 支持`AutoMapper`模块映射
- [ ] 支持`微信支付`（没账号）

****
#### 目录结构:

![图片](https://user-images.githubusercontent.com/68722157/138565689-ac6e2489-4b8f-47fd-93c1-47f26d453779.png)

我们依照DDD领域驱动设计分层

- BackGround：后台进程
- Client：客户端
- Domain：领域层
- Infrastructure：实例层
- MicroServiceInstance：服务层


另外，**分支ec电商**目录结构：

![image](https://user-images.githubusercontent.com/68722157/142923703-9c56cd4c-2201-4933-9b26-dcb3f9f2d1b8.png)


****
#### 安装教程:

我们将在之后更新教程手册！

1.  下载全部源码，默认使用sqlite数据库，已经生成
2.  使用Visual Studio 2019在windows环境中打开CC.Yi.sln文件即可

****
#### 使用说明:

我们将使用说明转移至我们的官方论坛中，正在制作中，尽情期待！

****
#### 感谢人员：

**国内.Net行业领头人中**： Eleven神、哲学的老张

**核心开发人员**：

[橙子]https://github.com/ccnetcore

[lzw]https://github.com/yeslode

[其他]https://github.com

****
#### 联系我们：

QQ：454313500

官方网址：正在建设

****
#### FQA:

问1：为何不采用经典的三层架构？

答1：EFcoreORM已经非常强大，已经完全可以充当数据处理层，另一个原因，在简单与复杂，我们选择了简单

问2：这个框架的一切都是原创的吗？

答2：并不是，我们在初期是参考过非常非常多的其他框架，但我们可以保证，基本上绝大部分都是原创。

问3：以后会持续更新下去吗？

答3：一定会的，我们的标题是 一个紧跟时代的.Netcore开源框架 ，如果有我们比较感兴趣的技术，我们一定会加入进来，例如：.Net6 。（已更新）

问4：这个框架的针对人群是哪些人？适合所有人吗？

答4：并不是适合所有人，应该算适合需要有一定基础的开发人员，当然，如果你是大神，你完全可以将这个框架改进！

问5：花如此多的精力制作这个框架，是为了什么？是为了赚钱吗？和目前主流的abp等框架比，又有什么意义呢？

答5：不说什么大话，制作这个框架主要原因是为了自己使用以及其他的参考学习。abp确实非常优秀，但和我们意框架其实并不冲突，使用场景是不一样的。

问6：为何不出版一个详细的说明书呢？

答5：应该不会了，代码都是基于Asp.Netcore框架，适用于新手不用造轮子，整个框架较为简单，阅读源码后，基本能自定义改造使用了，过难也已经封装完毕，别忘了，其意义是为了开发更加简易！

