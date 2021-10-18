public interface IRotatationChange
{
    int HandleId { get;}
    void OnRotationChange(int id, float deltaRotation);
}
