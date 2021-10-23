using System;
using System.Collections.Generic;
using Myk;


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

    public double       length          = 0.0D;
    public double       width           = 0.0D;
    protected ushort    numberOfMouths  = 2;
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


} // namespace Myk end.


class MainClass {
    public static void Main(string[] args) {
        Console.WriteLine("MainClass.Main 開始");
        RoadNode nodeN = new RoadNode();
        RoadNode nodeM = new RoadNode();
        RoadBase road = nodeN.Connect(new RoadBase(30, 5));
        nodeM.Connect(road);
        Console.WriteLine("MainClass.Main 終了");
        return;
    }
}

