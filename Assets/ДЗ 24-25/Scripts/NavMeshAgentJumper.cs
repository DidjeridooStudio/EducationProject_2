using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentJumper
{
    private float _jumpSpeed;
    private NavMeshAgent _agent;
    private MonoBehaviour _coroutinesRunner;
    private Coroutine _jumpProcess;

    public NavMeshAgentJumper(float jumpSpeed, NavMeshAgent agent, MonoBehaviour coroutinesRunner)
    {
        _jumpSpeed = jumpSpeed;
        _agent = agent;
        _coroutinesRunner = coroutinesRunner;
    }

    public bool InProcess => _jumpProcess != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if (InProcess)
            return;

        _jumpProcess = _coroutinesRunner.StartCoroutine(JumpProcess(offMeshLinkData));
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
    {
        float duration = Vector3.Distance(offMeshLinkData.startPos, offMeshLinkData.endPos) / _jumpSpeed;

        float progress = 0;

        while(progress < duration)
        {
            _agent.transform.position = Vector3.Lerp(offMeshLinkData.startPos, offMeshLinkData.endPos, progress / duration);
            progress += Time.deltaTime;

            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpProcess = null;
    }
}
