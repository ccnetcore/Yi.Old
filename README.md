<h1 align="center">Yi.Framework-基于.NET5+Vue快速开发框架</h1>
<h1 align="center">Yi意框架</h1>
<h4 align="center">意义为了开发更简易</h4>

#### 简介

**CC.Yi.Old**：.Net5早期三层架构Webapi架构

**CC.Yi**:.Net5三层架构WebApi架构

**CC.Yi.Framework**:.Net5DDD领域驱动设计分层微服务架构（正在更新）

**CC.Yi.Vue**：Vue2.0配合CC.Yi.Framework使用前端项目（正在更新）

#### 软件架构
架构：.NET5(.NetCore 5)

支持的关系型数据库：mysql、sql server、sqlite、oracle

支持的非关系型数据库：redis、mongodb

操作系统：Windows、Linux

身份验证：Identity、JWT

扩展：EFcore、Autofac、Identity、Castle、Swagger、T4、Nlog

封装：Json处理模块，滑动验证码模块，base64图片处理模块，异常捕捉模块、邮件处理模块、linq封装模块、随机数模块、统一接口模块、基于策略的jwt验证、过滤器、数据库连接、跨域、初始化

思想：简单工厂模式，抽象工厂模式，观察者模式，面向AOP思想，面向对象开发

代码自动生成：

 - T4DataContext（模型层数据库表）
 - T4IDAL
 - T4IDAL
 - T4IBLL
 - T4BLL
 - T4Startup（启动依赖注入）
 - T4api（vue前端api模板）
 - T4Component（vue前端增删改查模板）
 - T4Controller（控制器模板）

#### 目录结构
![输入图片说明](https://images.gitee.com/uploads/images/2021/0321/023715_59bef411_3049273.png "屏幕截图.png")

Model：模型层（first code代码优先添加模型，数据自动生成）

DAL：数据处理层（处理数据但并未加载进内存）

BLL：业务逻辑层（数据的逻辑将在这层处理）

Common：工具层（工具人层，方法已封装，一键调用）

API：接口层（接入Swagger，封装jwt授权，可视化测试接口）


#### 安装教程
我们将在之后更新教程手册！

1.  下载全部源码，默认使用sqlite数据库，已经生成
2.  使用Visual Studio 2019在windows环境中打开CC.Yi.sln文件即可


#### 使用说明
我们将在之后更新教程手册！

1.  修改连接数据库的配置文件
2.  添加模型类，进入模型层 使用Add-Migration xxx迁移，再使用Update-Database更新数据库
3.  向T4Model添加模型名，一键转换生成T4
4.  控制器构造函数进行依赖注入直接使用

#### 联系我们：
QQ：454313500


