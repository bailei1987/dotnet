﻿namespace BL.StandardDictionary
{
    /// <summary>
    /// 中等职业学校专业目录(2016修订)
    /// </summary>
    public class DicMajorsMedium : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("010000","农林牧渔类"),
                new DicItem("010100","设施农业生产技术"),
                new DicItem("010200","现代农艺技术"),
                new DicItem("010300","观光农业经营"),
                new DicItem("010400","循环农业生产与管理"),
                new DicItem("010500","种子生产与经营"),
                new DicItem("010600","植物保护"),
                new DicItem("010700","果蔬花卉生产技术"),
                new DicItem("010800","茶叶生产与加工"),
                new DicItem("010900","蚕桑生产与经营"),
                new DicItem("011000","中草药种植"),
                new DicItem("011100","棉花加工与检验"),
                new DicItem("011200","烟草生产与加工"),
                new DicItem("011300","现代林业技术"),
                new DicItem("011400","森林资源保护与管理"),
                new DicItem("011500","园林技术"),
                new DicItem("011600","园林绿化"),
                new DicItem("011700","木材加工"),
                new DicItem("011800","畜禽生产与疾病防治"),
                new DicItem("011900","特种动物养殖"),
                new DicItem("012000","畜牧兽医"),
                new DicItem("012100","宠物养护与经营"),
                new DicItem("012200","淡水养殖"),
                new DicItem("012300","海水生态养殖"),
                new DicItem("012400","航海捕捞"),
                new DicItem("012500","农产品保鲜与加工"),
                new DicItem("012600","农产品营销与储运"),
                new DicItem("012700","农业机械使用与维护"),
                new DicItem("012800","农村电气技术"),
                new DicItem("012900","农业与农村用水"),
                new DicItem("013000","农村环境监测"),
                new DicItem("013100","农村经济综合管理"),
                new DicItem("013200","农资连锁经营与管理"),
                new DicItem("019900","农林牧渔类新专业"),
                new DicItem("020000","资源环境类"),
                new DicItem("020100","国土资源调查"),
                new DicItem("020200","地质调查与找矿"),
                new DicItem("020300","水文地质与工程地质勘察"),
                new DicItem("020400","地球物理勘探"),
                new DicItem("020500","钻探工程技术"),
                new DicItem("020600","掘进工程技术"),
                new DicItem("020700","岩土工程勘察与施工"),
                new DicItem("020800","地质灾害调查与治理施工"),
                new DicItem("020900","地图制图与地理信息系统"),
                new DicItem("021000","地质与测量"),
                new DicItem("021100","水文与水资源勘测"),
                new DicItem("021200","采矿技术"),
                new DicItem("021300","矿山机械运行与维修"),
                new DicItem("021400","矿山机电"),
                new DicItem("021500","矿井通风与安全"),
                new DicItem("021600","矿井建设"),
                new DicItem("021700","煤炭综合利用"),
                new DicItem("021800","环境监测技术"),
                new DicItem("021900","环境管理"),
                new DicItem("022000","环境治理技术"),
                new DicItem("022100","生态环境保护"),
                new DicItem("022200","气象服务"),
                new DicItem("022300","雷电防护技术"),
                new DicItem("029900","资源环境类新专业"),
                new DicItem("030000","能源与新能源类"),
                new DicItem("030100","石油钻井"),
                new DicItem("030200","石油天然气开采"),
                new DicItem("030300","石油地质录井与测井"),
                new DicItem("030400","石油与天然气贮运"),
                new DicItem("030500","火电厂热力设备运行与检修"),
                new DicItem("030600","火电厂热力设备安装"),
                new DicItem("030700","火电厂热工仪表安装与检修"),
                new DicItem("030800","火电厂集控运行"),
                new DicItem("030900","火电厂水处理及化学监督"),
                new DicItem("031000","水电厂机电设备安装与运行"),
                new DicItem("031100","水泵站机电设备安装与运行"),
                new DicItem("031200","反应堆及核电厂运行"),
                new DicItem("031300","风电场机电设备运行与维护"),
                new DicItem("031400","太阳能与沼气技术利用"),
                new DicItem("031500","发电厂及变电站电气设备"),
                new DicItem("031600","继电保护及自动装置调试维护"),
                new DicItem("031700","输配电线路施工与运行"),
                new DicItem("031800","供用电技术"),
                new DicItem("031900","电力营销"),
                new DicItem("039900","能源与新能源类新专业"),
                new DicItem("040000","土木水利类"),
                new DicItem("040100","建筑工程施工"),
                new DicItem("040200","建筑装饰"),
                new DicItem("040300","古建筑修缮与仿建"),
                new DicItem("040400","城镇建设"),
                new DicItem("040500","工程造价"),
                new DicItem("040600","建筑设备安装"),
                new DicItem("040700","楼宇智能化设备安装与运行"),
                new DicItem("040800","供热通风与空调施工运行"),
                new DicItem("040900","建筑表现"),
                new DicItem("041100","给排水工程施工与运行"),
                new DicItem("041100","0 城市燃气输配与应用"),
                new DicItem("041200","市政工程施工"),
                new DicItem("041300","道路与桥梁工程施工"),
                new DicItem("041400","铁道施工与养护"),
                new DicItem("041500","水利水电工程施工"),
                new DicItem("041600","工程测量"),
                new DicItem("041700","土建工程检测"),
                new DicItem("041800","工程机械运用与维修"),
                new DicItem("049900","土木水利类新专业"),
                new DicItem("050000","加工制造类"),
                new DicItem("050100","钢铁冶炼"),
                new DicItem("050200","金属压力加工"),
                new DicItem("050300","工程材料检测技术"),
                new DicItem("050400","钢铁装备运行与维护"),
                new DicItem("050500","有色装备运行与维护"),
                new DicItem("050600","建材装备运行与维护"),
                new DicItem("050700","有色金属冶炼"),
                new DicItem("050800","建筑与工程材料"),
                new DicItem("050900","硅酸盐工艺及工业控制"),
                new DicItem("051000","选矿技术"),
                new DicItem("051100","机械制造技术"),
                new DicItem("051200","机械加工技术"),
                new DicItem("051300","机电技术应用"),
                new DicItem("051400","数控技术应用"),
                new DicItem("051500","模具制造技术"),
                new DicItem("051600","机电设备安装与维修"),
                new DicItem("051700","汽车制造与检修"),
                new DicItem("051800","汽车电子技术应用"),
                new DicItem("051900","船舶制造与修理"),
                new DicItem("052000","船舶机械装置安装与维修"),
                new DicItem("052100","金属热加工"),
                new DicItem("052200","焊接技术应用"),
                new DicItem("052300","机电产品检测技术应用"),
                new DicItem("052400","金属表面处理技术应用"),
                new DicItem("052500","工业自动化仪表及应用"),
                new DicItem("052600","医疗设备安装与维护"),
                new DicItem("052700","电机电器制造与维修"),
                new DicItem("052800","光电仪器制造与维修"),
                new DicItem("052900","制冷和空调设备运行与维修"),
                new DicItem("053000","电气运行与控制"),
                new DicItem("053100","电气技术应用"),
                new DicItem("053200","电子电器应用与维修"),
                new DicItem("053300","电子材料与元器件制造"),
                new DicItem("053400","微电子技术与器件制造"),
                new DicItem("059900","加工制造类新专业"),
                new DicItem("060000","石油化工类"),
                new DicItem("060100","化学工艺"),
                new DicItem("060200","工业分析与检验"),
                new DicItem("060300","石油炼制"),
                new DicItem("060400","化工机械与设备"),
                new DicItem("060500","化工仪表及自动化"),
                new DicItem("060600","精细化工"),
                new DicItem("060700","生物化工"),
                new DicItem("060800","高分子材料加工工艺"),
                new DicItem("060900","橡胶工艺"),
                new DicItem("061000","林产化工"),
                new DicItem("061100","核化学化工"),
                new DicItem("061200","火炸药技术"),
                new DicItem("061300","花炮生产与管理"),
                new DicItem("069900","石油化工类新专业"),
                new DicItem("070000","轻纺食品类"),
                new DicItem("070100","制浆造纸工艺"),
                new DicItem("070200","平面媒体印制技术"),
                new DicItem("070300","塑料成型"),
                new DicItem("070400","纺织技术及营销"),
                new DicItem("070500","纺织高分子材料工艺"),
                new DicItem("070600","丝绸工艺"),
                new DicItem("070700","染整技术"),
                new DicItem("070800","针织工艺"),
                new DicItem("070900","服装制作与生产管理"),
                new DicItem("071000","皮革工艺"),
                new DicItem("071100","食品生物工艺"),
                new DicItem("071200","民族风味食品加工制作"),
                new DicItem("071300","粮油饲料加工技术"),
                new DicItem("071400","粮油储运与检验技术"),
                new DicItem("071500","家具设计与制作"),
                new DicItem("079900","轻纺食品类新专业"),
                new DicItem("080000","交通运输类"),
                new DicItem("080100","铁道运输管理"),
                new DicItem("080200","电力机车运用与检修"),
                new DicItem("080300","内燃机车运用与检修"),
                new DicItem("080400","铁道车辆运用与检修"),
                new DicItem("080500","电气化铁道供电"),
                new DicItem("080600","铁道信号"),
                new DicItem("080700","城市轨道交通运营管理"),
                new DicItem("080800","城市轨道交通车辆运用与检修"),
                new DicItem("080900","城市轨道交通供电"),
                new DicItem("081000","城市轨道交通信号"),
                new DicItem("081100","船舶驾驶"),
                new DicItem("081200","轮机管理"),
                new DicItem("081300","船舶水手与机工"),
                new DicItem("081400","船舶电气技术"),
                new DicItem("081500","船舶通信与导航"),
                new DicItem("081600","外轮理货"),
                new DicItem("081700","船舶检验"),
                new DicItem("081800","港口机械运行与维护"),
                new DicItem("081900","工程潜水"),
                new DicItem("082000","水路运输管理"),
                new DicItem("082100","民航运输"),
                new DicItem("082200","飞机维修"),
                new DicItem("082300","航空服务"),
                new DicItem("082400","航空油料管理"),
                new DicItem("082500","汽车运用与维修"),
                new DicItem("082600","汽车车身修复"),
                new DicItem("082700","汽车美容与装潢"),
                new DicItem("082800","汽车整车与配件营销"),
                new DicItem("082900","公路运输管理"),
                new DicItem("083000","公路养护与管理"),
                new DicItem("089900","交通运输类新专业"),
                new DicItem("090000","信息技术类"),
                new DicItem("090100","计算机应用"),
                new DicItem("090200","数字媒体技术应用"),
                new DicItem("090300","计算机平面设计"),
                new DicItem("090400","计算机动漫与游戏制作"),
                new DicItem("090500","计算机网络技术"),
                new DicItem("090600","网站建设与管理"),
                new DicItem("090700","网络安防系统安装与维护"),
                new DicItem("090800","软件与信息服务"),
                new DicItem("090900","客户信息服务"),
                new DicItem("091000","计算机速录"),
                new DicItem("091100","计算机与数码产品维修"),
                new DicItem("091200","电子与信息技术"),
                new DicItem("091300","电子技术应用"),
                new DicItem("091400","数字广播电视技术"),
                new DicItem("091500","通信技术"),
                new DicItem("091600","通信运营服务"),
                new DicItem("091700","通信系统工程安装与维护"),
                new DicItem("091800","邮政通信管理"),
                new DicItem("099900","信息技术类新专业"),
                new DicItem("100000","医药卫生类"),
                new DicItem("100100","护理"),
                new DicItem("100200","助产"),
                new DicItem("100300","农村医学"),
                new DicItem("100400","营养与保健"),
                new DicItem("100500","康复技术"),
                new DicItem("100600","眼视光与配镜"),
                new DicItem("100700","医学检验技术"),
                new DicItem("100800","医学影像技术"),
                new DicItem("100900","口腔修复工艺"),
                new DicItem("101000","医学生物技术"),
                new DicItem("101100","药剂"),
                new DicItem("101200","中医护理"),
                new DicItem("101300","中医"),
                new DicItem("101400","藏医医疗与藏药"),
                new DicItem("101500","维艺医疗与维药"),
                new DicItem("101600","蒙医医疗与蒙药"),
                new DicItem("101700","中医康复保健"),
                new DicItem("101800","中药"),
                new DicItem("101900","中药制药"),
                new DicItem("102000","制药技术"),
                new DicItem("102100","生物技术制药"),
                new DicItem("102200","药品食品检验"),
                new DicItem("102300","医疗器械维修与营销"),
                new DicItem("102400","制药设备维修"),
                new DicItem("102500","计划生育与生殖健康咨询"),
                new DicItem("102600","人口与计划生育管理"),
                new DicItem("102700","卫生信息管理"),
                new DicItem("102800","医药卫生财会"),
                new DicItem("109900","医药卫生类新专业"),
                new DicItem("110000","休闲保健类"),
                new DicItem("110100","美容美体"),
                new DicItem("110200","美发与形象设计"),
                new DicItem("110300","健体塑身"),
                new DicItem("110400","休闲服务"),
                new DicItem("119900","休闲保健类新专业"),
                new DicItem("120000","财经商贸类"),
                new DicItem("120100","会计"),
                new DicItem("120200","会计电算化"),
                new DicItem("120300","统计事务"),
                new DicItem("120400","金融事务"),
                new DicItem("120500","保险事务"),
                new DicItem("120600","信托事务"),
                new DicItem("120700","商品经营"),
                new DicItem("120800","专卖品经营"),
                new DicItem("120900","连锁经营与管理"),
                new DicItem("121000","市场营销"),
                new DicItem("121100","电子商务"),
                new DicItem("121200","国际商务"),
                new DicItem("121300","商务英语"),
                new DicItem("121400","商务日语"),
                new DicItem("121500","商务德语"),
                new DicItem("121600","商务韩语"),
                new DicItem("121700","商务俄语"),
                new DicItem("121800","商务法语"),
                new DicItem("121900","物流服务与管理"),
                new DicItem("122000","房地产营销与管理"),
                new DicItem("122100","客户服务"),
                new DicItem("129900","财经商贸类新专业"),
                new DicItem("130000","旅游服务类"),
                new DicItem("130100","酒店服务与管理"),
                new DicItem("130200","旅游服务与管理"),
                new DicItem("130300","旅游外语"),
                new DicItem("130400","导游服务"),
                new DicItem("130500","景区服务与管理"),
                new DicItem("130600","会展服务与管理"),
                new DicItem("130700","中餐烹饪"),
                new DicItem("130800","西餐烹饪"),
                new DicItem("130900","钟表维修"),
                new DicItem("139900","旅游服务类新专业"),
                new DicItem("140000","文化艺术类"),
                new DicItem("140100","社会文化艺术"),
                new DicItem("140200","广播影视节目制作"),
                new DicItem("140300","播音与节目主持"),
                new DicItem("140400","影像与影视技术"),
                new DicItem("140500","图书信息管理"),
                new DicItem("140600","出版与发行"),
                new DicItem("140700","文物保护技术"),
                new DicItem("140800","音乐"),
                new DicItem("140900","舞蹈表演"),
                new DicItem("141000","戏曲表演"),
                new DicItem("141100","曲艺表演"),
                new DicItem("141200","戏剧表演"),
                new DicItem("141300","杂技与魔术表演"),
                new DicItem("141400","木偶与皮影表演及制作"),
                new DicItem("141500","乐器修造"),
                new DicItem("141600","计算机音乐制作"),
                new DicItem("141700","动漫游戏"),
                new DicItem("141800","网页美术设计"),
                new DicItem("141900","数字影像技术"),
                new DicItem("142000","工艺美术"),
                new DicItem("142100","美术绘画"),
                new DicItem("142200","美术设计与制作"),
                new DicItem("142300","商品画制作与经营"),
                new DicItem("142400","服装设计与工艺"),
                new DicItem("142500","服装展示与礼仪"),
                new DicItem("142600","皮革制品造型设计"),
                new DicItem("142700","珠宝玉石加工与营销"),
                new DicItem("142800","民间传统工艺"),
                new DicItem("142900","民族音乐与舞蹈"),
                new DicItem("143000","民族乐器修造"),
                new DicItem("143100","民族美术"),
                new DicItem("143200","民族服装与服饰"),
                new DicItem("143300","民族织绣"),
                new DicItem("143400","民族民居装饰"),
                new DicItem("143500","民族工艺品制作"),
                new DicItem("149900","文化艺术类新专业"),
                new DicItem("150000","体育与健身类"),
                new DicItem("150100","运动训练"),
                new DicItem("150200","休闲体育服务与管理"),
                new DicItem("150300","体育设施管理与经营"),
                new DicItem("159900","体育与健身新专业"),
                new DicItem("160000","教育类"),
                new DicItem("160100","学前教育"),
                new DicItem("169900","教育类新专业"),
                new DicItem("170000","司法服务类"),
                new DicItem("170100","法律事务"),
                new DicItem("170200","社区法律服务"),
                new DicItem("170300","保安"),
                new DicItem("179900","司法服务类新专业"),
                new DicItem("180000","公共管理与服务类"),
                new DicItem("180100","办公室文员"),
                new DicItem("180200","文秘"),
                new DicItem("180300","商务助理"),
                new DicItem("180400","公关礼仪"),
                new DicItem("180500","工商行政管理事务"),
                new DicItem("180600","人力资源管理事务"),
                new DicItem("180700","物业管理"),
                new DicItem("180800","产品质量监督检验"),
                new DicItem("180900","民政服务与管理"),
                new DicItem("181000","社区公共事务管理"),
                new DicItem("181100","社会保障事务"),
                new DicItem("181200","社会福利事业管理"),
                new DicItem("181300","家政服务与管理"),
                new DicItem("181400","老年人服务与管理"),
                new DicItem("181500","现代殡仪技术与管理"),
                new DicItem("189900","公共管理与服务类新专业"),
                new DicItem("190000","其他"),
                new DicItem("199900","其他新专业"),
            };
            
        }
    }
}
