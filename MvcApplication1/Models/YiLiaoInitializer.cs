using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace MvcApplication1.Models
{
    public class YiLiaoInitializer:DropCreateDatabaseIfModelChanges<YiLiaoContext>
    {
        protected override void Seed(YiLiaoContext context)
        {
            

            var Health = new List<HealthModels>
            {
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康讲坛",HealthTypeName="健康讲坛",Content="健康讲坛",PubDate=DateTime.Now,UserName="admin",Remark="321"},

                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="疾病常识",HealthTypeName="疾病常识",Content="疾病常识",PubDate=DateTime.Now,UserName="admin",Remark="321"},

                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健教视频",HealthTypeName="健教视频",Content="健教视频",PubDate=DateTime.Now,UserName="admin",Remark="321"},

                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="寻医问药",HealthTypeName="寻医问药",Content="寻医问药",PubDate=DateTime.Now,UserName="admin",Remark="321"},

                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
                new HealthModels{HealthHead="健康者俱乐部",HealthTypeName="健康者俱乐部",Content="健康者俱乐部",PubDate=DateTime.Now,UserName="admin",Remark="321"},
            };
            Health.ForEach(s => context.HealthModels.Add(s));
            context.SaveChanges();

            var user = new List<UsersModels>
                {
                    new UsersModels {UserName = "admin", UserPassword = "7EE9874CFCE93C64", Limit = "admin",Sex = "男",Email = "zdp100@gmail.com",RegisterDate = DateTime.Now}
                };
   
            user.ForEach(s=>context.UsersModels.Add(s));
            context.SaveChanges();

            

            var singlePgae = new List<SinglePageModels>
                {
                    new SinglePageModels {Title = "医院简介", Content = "医院简介",Type = "医院概况"},//1
                    new SinglePageModels {Title="组织架构",Content = "组织架构",Type = "医院概况"},//2

                    new SinglePageModels {Title="门诊指南",Content = "门诊指南",Type = "就医指南"},//3
                    new SinglePageModels {Title="出诊信息",Content = "出诊信息",Type = "就医指南"},//4
                    new SinglePageModels {Title="挂号须知",Content = "挂号须知",Type = "就医指南"},//5
                    new SinglePageModels {Title="网上预约",Content = "网上预约",Type = "就医指南"},//6
                    new SinglePageModels {Title="检验检查须知",Content = "检验检查须知",Type = "就医指南"},//7
                    new SinglePageModels {Title="出入院导航",Content = "出入院导航",Type = "就医指南"},//8
                    new SinglePageModels {Title="患者安全须知",Content = "患者安全须知",Type = "就医指南"},//9
                    new SinglePageModels {Title="方位指南",Content = "方位指南",Type = "就医指南"},//10
                    new SinglePageModels {Title="个人费用查绚",Content = "个人费用查绚",Type = "就医指南"},//11
                    new SinglePageModels {Title="检查结果查询",Content = "检查结果查询",Type = "就医指南"},//12

                    new SinglePageModels {Title="院训",Content = "院训",Type = "医院文化"},//13
                    new SinglePageModels {Title="院徽院歌",Content = "院徽院歌",Type = "医院文化"},//14
                    new SinglePageModels {Title="医院故事",Content = "医院故事",Type = "医院文化"},//15
                    new SinglePageModels {Title="院史",Content = "院史",Type = "医院文化"},//16
                    new SinglePageModels {Title="文学社",Content = "文学社",Type = "医院文化"},//17

                    new SinglePageModels {Title="联系我们",Content = "联系我们",Type = "医院概况"}//18

                };
            singlePgae.ForEach(s=>context.SinglePageModels.Add(s));
            context.SaveChanges();

            var reader = new List<ReadersModels>
                {
                    new ReadersModels{ReaderName = "韦秋云",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云1",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云2",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云3",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云4",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云5",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"},
                    new ReadersModels{ReaderName = "韦秋云6",Position = "打杂",Sex = "女",Images = "/UploadFile/image/39e0871c-72b6-440d-b09a-6e1876a46a0d.jpg",Duty = "喜欢喊人去吃饭",Email = "123@123.123"}
                };
            reader.ForEach(s=>context.ReadersModels.Add(s));
            context.SaveChanges();

            var doctor = new List<DoctorsModels>
                {
                     new DoctorsModels{DoctorName = "韦秋云",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云1",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云2",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云3",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云4",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云5",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云6",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云7",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now},
                     new DoctorsModels{DoctorName = "韦秋云8",sex = "女",Images = "/UploadFile/image/1.jpg",KeySkill = "喜欢喊人去吃饭",Email = "123@123.123",Birthday = DateTime.Now}
                };
            doctor.ForEach(s=>context.DoctorsModels.Add(s));
            context.SaveChanges();

            var news = new List<NewsModels>
                {
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "动态新闻",PubDate = DateTime.Now},

                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "媒体聚焦",PubDate = DateTime.Now},

                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "电子院刊",PubDate = DateTime.Now},

                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now},
                    new NewsModels{Title = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",Content = "热烈庆祝桂林电子科技大学校医院门户网站建设成功",NewType = "科室传真",PubDate = DateTime.Now}
                };
            news.ForEach(s=>context.NewsModels.Add(s));
            context.SaveChanges();

            var MedicalTech=new List<MedicalTechModels>()
                {
                    new MedicalTechModels{Title = "特色医疗",Type = "特色医疗",Content = "特色医疗",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "特色医疗",Type = "特色医疗",Content = "特色医疗",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "特色医疗",Type = "特色医疗",Content = "特色医疗",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "特色医疗",Type = "特色医疗",Content = "特色医疗",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "特色医疗",Type = "特色医疗",Content = "特色医疗",PubDate = DateTime.Now,UserName = "Admin"},

                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "新技术新疗法",Type = "新技术新疗法",Content = "新技术新疗法",PubDate = DateTime.Now,UserName = "Admin"},

                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"},
                    new MedicalTechModels{Title = "先进设备",Type = "先进设备",Content = "先进设备",PubDate = DateTime.Now,UserName = "Admin"}
                };
            MedicalTech.ForEach(s=>context.MedicalTechModels.Add(s));
            context.SaveChanges();

            var message = new List<MessageInfoModels>
                {
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                    new MessageInfoModels() {Title = "今天太阳真好",Content = "今天太阳真好",PubDate = DateTime.Parse("2013-4-10"),UserName = "admin",userId = 1,ReplyNum = 0,ViewNum = 0},
                };
            message.ForEach(m=>context.MessageInfoModels.Add(m));
            context.SaveChanges();

            var reply = new List<ReplyModel>
                {
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 1,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 2,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 3,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                    new ReplyModel() {Content = "今天太阳真好+1", PubDate = DateTime.Parse("2013-4-10"),MessageId = 4,userId = 1},
                };
            reply.ForEach(r=>context.ReplyModel.Add(r));
            context.SaveChanges();
        }
    }
}