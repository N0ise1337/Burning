namespace Burning.DofusProtocol.Data.D2P.Utils
{
  public class Point
  {
    public Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public Point()
    {
    }

    public int X { get; set; }

    public int Y { get; set; }
  }
}
