using System;
using System.Collections.Generic;
using Myk;
using NL1;


namespace Myk {

class TrafficMember {
    public int speed = 0;
    public uint id = 0;
}


//車
class Car : TrafficMember {
}


class RoadParts {
    public string namea = "no name";
    uint id = 0;
}


//道路
class RoadBase : RoadParts {

    public double       length { get; set; }   = 0.0D; //単位(m)
    public double       width  { get; set; }   = 0.0D; //単位(m)
    protected ushort    numberOfMouths { get; } = 2;
    private ushort      mouthsUsed      = 0;

    public RoadBase(double length, double width) {
        length = length;
        width = width;
    }

    public virtual bool Connectable() {
        if (numberOfMouths > mouthsUsed) {
            return true;
        } else {
            return false;
        }
    }

    public bool ConnectRoad(RoadBase road) {
        if (!Connectable())  return false;
    } 

    public void CountUp() {
        mouthsUsed++;
    }

}


//信号機
class TrafficLight {

    public enum Status {
        red,
        yellow,
        blue,
        special,
        length
    };

    public Status status = Status.red;

    public TrafficLight(Status status) {
        status = status;
    }

}

//道路の通過点
class RoadNode : RoadParts {

    public double           xPoint, yPoint      = 0;
    public TrafficLight     trafficLight        = null;
    public List<RoadBase>   connectedRoadvec    = new List<RoadBase>();

    public RoadNode() : this(0, 0) { }

    public RoadNode(double x, double y) {
        xPoint = x;
        yPoint = y;
    }

    public RoadBase Connect(RoadBase road) {
        if (road.Connectable() == false) return null; 
        connectedRoadvec.Add(road);
        return road;
    }

}

//道路の交差点
class InterSection : RoadNode { }

class RoadBuild {
    public static RoadBase Start() {
        RoadNode nodestart = new RoadNode();
        RoadBase road = nodestart.Connect(new RoadBase(50, 5));
        return road;
    }
}

} // namespace Myk end.


class Test {
    public int count = 0;

    public void set(Func<int, int> f) {
        f(count);
    }

    public void set(int val) {
        count = val;
    }


}

class MainClass {

    public static void Main(string[] args) {
//        Console.WriteLine("MainClass.Main 開始");
//        RoadNode nodeN = new RoadNode();
//        RoadNode nodeM = new RoadNode();
//        RoadBase road = nodeN.Connect(new RoadBase(30, 5));
//        nodeM.Connect(road);
        //var a = RoadBuild.Start()
        Test t = new Test();
        t.set(t.count + 1); //即時評価
        t.set( x =>  x + 1 ); //遅延評価
        
        Console.WriteLine("MainClass.Main 終了");
        return;
    }

}

//namespace NL1 {
    //namespace NL2 {
    namespace NL1.NL2 {
        class Foo {
            public Foo() {
                Console.WriteLine("NL1::NL2::Foo#Foo");
            }
        }
    }
//}

namespace NL2 {
    class Foo {
        public Foo() {
            Console.WriteLine("NL2::Foo#Foo");
        }
    }
}
