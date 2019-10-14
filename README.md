# QuartzServer
基于Quartz.Net组件实现定时任务调度
## 前言：
这个时候，如果你和你的团队是用.NET编程的话，可以考虑使用Quartz.NET调度器。允许开发人员根据日期间隔来实现任务调度任务。非常适合在平时的工作中，定时轮询数据库同步，定时邮件通知，定时处理数据等。
我们通过利用控制台实现定时任务调度，已经大致了解了如何基于Quartz.Net组件实现任务，至少包括三部分：job(作业），trigger（触发器），scheduler（调度器）。其中job是需要在一个定时任务中具体执行的业务逻辑，trigger通过规定job何时并按照何种指定的规则进行执行，最后job和trigger会被注册到scheduler中，利用scheduler（调度器）来负责协调job和trigger的搭配运行。


![image text](https://github.com/Goal-developer/QuartzServer/blob/master/readimage/quartz.png)
