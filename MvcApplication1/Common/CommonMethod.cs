using System.Collections.Generic;

namespace MvcApplication1.Common
{
    public class CommonMethod
    {
        public List<string> Sexlist()
        {
            List<string> list=new List<string>();
            list.Add("男");
            list.Add("女");
            return list;
        }
        public List<string> SinglePageList()
        {
            List<string> List = new List<string>();
            List.Add("医院概况");
            List.Add("就医指南");
            List.Add("医院文化");
            return List;
        }
        public List<string> MedicaTechList()
        {
            List<string> List = new List<string>();
            List.Add("特色医疗");
            List.Add("新技术新疗法");
            List.Add("先进设备");
            return List;
        }

        public List<string> HealthList()
        {
            List<string> List = new List<string>();
            List.Add("健康讲坛");
            List.Add("疾病常识");
            List.Add("健教视频");
            List.Add("寻医问药");
            List.Add("健康者俱乐部");
            return List;
        }
    }
}