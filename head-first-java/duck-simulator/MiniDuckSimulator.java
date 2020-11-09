public class MiniDuckSimulator{
    public static void main(String[] args) {
        //Duck mallard = new Duck();
        //System.out.print("Duck Simulator!!");

        Duck mallard = new MallardDuck();
        mallard.performQuack();
        mallard.performFly();
    }
}